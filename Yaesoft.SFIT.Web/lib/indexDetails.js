//作品明细。
$(function() {
    var wid = $("#IndexDetails_WorkID").val();
    //加载图片。
    $(".archives_pic img").attr("src", "WorkThumbnails.ashx?id=" + wid + "&w=200&h=133");
    $(".archives_pic img").lazyload({
        placeholder: "../Include/ar01.jpg",
        threshold: 200,
        effect: "fadeIn"
    });
    var comment = $(".comment textarea");
    $(".reback input[type=button]").on("click", function() {
        var result = comment.validatebox("isValid");
        if (result) {
            $.ajax({
                url: "IndexData.ashx",
                type: "POST",
                data: {
                    type: "post",
                    uid: wid,
                    gid: $("#IndexDetails_ClientIP").val(),
                    cid: $("#IndexDetails_UserName").val(),
                    sid: comment.val()
                },
                dataType: "json",
                success: function(data) {
                    $.messager.show({
                        title: "提示信息",
                        msg: data.Message
                    });
                    if (data.Success) {
                        comment.val("");
                        loadComment({
                            size: 5,
                            index: 1
                        });
                    }
                }
            });
        }
    });
    loadComment({
        size: 5,
        index: 1
    });
    //加载评论。
    function loadComment(opts) {
        var comment = $(".comment_list");
        if (comment && wid && opts) {
            loadMask(comment);
            $.ajax({
                url: "IndexData.ashx",
                type: "POST",
                data: {
                    type: "comment",
                    uid: wid,
                    page: opts.size,
                    index: opts.index
                },
                dataType: "json",
                success: function(data) {
                    removeMaskClass(".comment_list");
                    comment.off();
                    comment.empty();
                    if (data.Success) {
                        //生成作业。
                        $.each(data.Data.Items, function(i, t) {
                            var html = "<li><div class=\"name\">";
                            html += "<span>" + t.IP + "</span>";
                            html += "<em>" + t.Time + "</em>";
                            html += "</div>";
                            html += "<div class=\"con\">" + t.Comment + "</div>";
                            html += "</li>";
                            comment.append(html);
                        });
                        //处理分页。
                        var index = data.Data.PI;
                        var count = data.Data.PC;
                        var rows = data.Data.RC;
                        var isFirst = ((index == 1) || (count == 1));
                        var isLast = (index == count);
                        var p = $(".page");
                        if (p) {
                            p.off();
                            p.empty();
                            if (count == 0) {
                                return;
                            }
                            //上一页。
                            var html = "<a class=\"pre\" href=\"javascript:void(0)\">&nbsp;</a>";
                            //首页。
                            if (isFirst) {
                                html += "<span>1</span>";
                            } else {
                                html += "<a href=\"javascript:void(0)\">1</a>";
                            }
                            //中间枚举。
                            if (count > 1) {
                                if (index > 3) {
                                    html += "...";
                                }
                                //前两页。
                                for (var i = index - 2; i < index; i++) {
                                    if (i > 1) {
                                        html += "<a href=\"javascript:void(0)\">" + i + "</a>";
                                    }
                                }
                                //当前页。
                                if (!isFirst && !isLast) {
                                    html += "<span>" + index + "</span>";
                                }
                                //后两页
                                for (var i = index; i <= index + 2; i++) {
                                    if (i > index && i < count) {
                                        html += "<a href=\"javascript:void(0)\">" + i + "</a>";
                                    }
                                }
                                if (index + 2 < count) {
                                    html += "...";
                                }
                                //尾页
                                if (isLast) {
                                    html += "<span>" + index + "</span>";
                                } else {
                                    html += "<a href=\"javascript:void(0)\">" + count + "</a>";
                                }
                            }
                            //下一页。
                            html += "<a href=\"javascript:void(0)\" class=\"next\">&nbsp;</a>到第";
                            html += "<dl>";
                            html += "<dt><input type=\"text\" />页</dt>";
                            html += "</dl><input type=\"button\" value=\"确定\" class=\"button\" />";
                            html += "<dt>(共" + rows + "条)</dt>";
                            p.append(html);
                            p.find("input[type=text]").numberbox({
                                min: 1,
                                max: count,
                                precision: 0
                            });
                            //指定页。
                            p.find("a").click(function() {
                                var txt = $.trim($(this).text());
                                if (txt && txt.length > 0) {
                                    opts.index = txt;
                                    loadComment(opts);
                                }
                            });
                            //上一页。
                            if (!isFirst) {
                                p.find("a[class=pre]").click(function() {
                                    var i = parseInt(opts.index);
                                    if (i > 0) {
                                        opts.index = i - 1;
                                        loadComment(opts);
                                    }
                                });
                            }
                            //下一页。
                            if (!isLast) {
                                p.find("a[class=next]").click(function() {
                                    var i = parseInt(opts.index);
                                    if (i < count) {
                                        opts.index = i + 1;
                                        loadComment(opts);
                                    }
                                });
                            }
                            //任意页。
                            p.find("input[type=button]").click(function() {
                                var v = p.find("input[type=text]").val();
                                if (v && (v >= 1 && v <= count)) {
                                    opts.index = parseInt(v);
                                    loadComment(opts);
                                }
                            });
                        }
                    } else {
                        $.messager.show({
                            title: "加载评论数据异常！",
                            msg: data.Message
                        });
                    }
                }
            });
        }
    }
});