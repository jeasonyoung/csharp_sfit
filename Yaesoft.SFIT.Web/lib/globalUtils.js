//验证扩展。
$.extend($.fn.validatebox.defaults.rules, {
    regex: {
        validator: function(value, param) {
            if (value && value.length > 0 && param[0]) {
                var reg = new RegExp(param[0]);
                return reg.test(value);
            }
            return true;
        },
        message: "{1}"
    }
});
//全局工具脚本。
$(function() {
    //隐藏样式数据。
    $(".hot_works").hide();
    //鼠标移动效果。
    $(".hot_works li").mouseenter(function() {
        $(this).find("img").addClass("current");
    });
    $(".hot_works li").mouseleave(function() {
        $(this).find("img").removeClass("current");
    });
    //给对象加载遮罩。
    loadMask = function(obj) {
        if (obj) {
            var offset = obj.offset();
            $("<span>正在加载，请稍候...</span>").css({
                "margin-top": (obj.height() / 2) - 10,
                "margin-left": 5
            }).appendTo($("<div class=\"ext-load-mask\"></div>").css({
                top: offset.top,
                left: offset.left,
                width: obj.width(),
                height: obj.height(),
                display: "block"
            }).appendTo(obj));
        }
    };
    //移除对象的遮罩。
    removeMask = function(id) {
        if (id) {
            //console.info($("#" + id + " div[class=ext-load-mask]"));
            var o = $("#" + id + " div[class=ext-load-mask]");
            if (o) {
                o.remove();
            }
        }
    };
    removeMaskClass = function(css) {
        if (css) {
            var o = $(css + " div[class=ext-load-mask]");
            if (o) {
                o.remove();
            }
        }
    };
    //加载菜单数据。
    //type, uid, page, size, fn, fnClick
    loadMenuData = function(opts) {
        if (opts && opts.type) {
            loadMask(($("#index_leftMenu")));
            $.ajax({
                url: "IndexData.ashx",
                type: "POST",
                data: {
                    type: opts.type || '',
                    uid: opts.uid || '',
                    gid: opts.gid || '',
                    cid: opts.cid || '',
                    page: opts.size,
                    index: opts.index
                },
                dataType: "json",
                success: function(data) {
                    removeMask("index_leftMenu");
                    var o = $("#index_leftMenu dl[class=sidebar_list]");
                    if (o) {
                        o.off();
                        o.empty(); //清空菜单数据。
                    } else {
                        return;
                    }
                    if (data.Success) {
                        //装载新菜单数据。
                        if (opts.fn) {
                            $.each(data.Data.Items, function(i, t) {
                                var html = opts.fn(i, t);
                                if (html) {
                                    o.append(html);
                                }
                            });
                        }
                        //绑定事件。
                        var objs = o.find(".clearfix");
                        if (objs) {
                            $.each(objs, function(i, n) {
                                $(this).on("click", function() {
                                    var css = o.find(".current");
                                    if (css) {
                                        css.removeClass("current");
                                    }
                                    $(this).addClass("current");
                                    if (opts.fnClick) {
                                        opts.fnClick($(this));
                                    }
                                });
                            });
                        }
                        //分页。
                        var index = data.Data.PI;
                        var count = data.Data.PC;
                        //上一页。
                        var prev = $("#index_leftMenu div[class=sidebar_page] dd[class=previewpage]");
                        if (prev) {
                            prev.off();
                            prev.empty();
                            if (index > 1) {
                                var htmlPrev = "<a href=\"javascript:void(0)\"></a>";
                                prev.append(htmlPrev);
                                prev.on("click", function() {
                                    var i = parseInt(opts.index);
                                    if (i > 0) {
                                        opts.index = i - 1;
                                        loadMenuData(opts);
                                    }
                                });
                            }
                        }
                        //显示。
                        $("#index_leftMenu div[class=sidebar_page] dl[class=clearfix] dt").html(index + "/" + count);
                        //下一页。
                        var next = $("#index_leftMenu div[class=sidebar_page] dd[class=nextpage]");
                        if (next) {
                            next.off();
                            next.empty();
                            if (index < count) {
                                var htmlNext = "<a href=\"javascript:void(0)\"></a>";
                                next.append(htmlNext);
                                next.on("click", function() {
                                    var i = parseInt(opts.index);
                                    if (i < count) {
                                        opts.index = i + 1;
                                        loadMenuData(opts);
                                    }
                                });
                            }
                        }
                        //全部加载成功后调用方法。
                        if (opts.fnLoad) {
                            opts.fnLoad(o);
                        }
                    } else {
                        $.messager.show({
                            title: "获取菜单数据异常！",
                            msg: data.Message
                        });
                    }
                }
            });
        }
    };
    //加载作品数据通用函数。
    //id,type, uid, cid, sid, size, index, fn
    LoadWorks = function(opts) {
        if (opts && opts.id) {
            loadMask(($("#" + opts.id)));
            $.ajax({
                url: "IndexData.ashx",
                type: "POST",
                data: {
                    type: opts.type || opts.id,
                    uid: opts.uid || '',
                    cid: opts.cid || '',
                    sid: opts.sid || '',
                    st: opts.st || '',
                    page: opts.size,
                    index: opts.index
                },
                dataType: "json",
                success: function(data) {
                    removeMask(opts.id);
                    var o = $("#" + opts.id + " ul[class=clearfix]");
                    if (o) {
                        o.off();
                        o.empty();
                    } else {
                        return;
                    }
                    if (data.Success) {
                        if (opts.fn) {
                            //生成作业。
                            $.each(data.Data.Items, function(i, t) {
                                var html = opts.fn(i, t);
                                if (html) {
                                    o.append(html);
                                }
                            });
                            //处理分页。
                            var index = data.Data.PI;
                            var count = data.Data.PC;
                            var rows = data.Data.RC;
                            var isFirst = ((index == 1) || (count == 1));
                            var isLast = (index == count);
                            var p = $("#" + opts.id + " div[class=page]");
                            if (p) {
                                p.off();
                                p.empty();
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
                                        LoadWorks(opts);
                                    }
                                });
                                //上一页。
                                if (!isFirst) {
                                    p.find("a[class=pre]").click(function() {
                                        var i = parseInt(opts.index);
                                        if (i > 0) {
                                            opts.index = i - 1;
                                            LoadWorks(opts);
                                        }
                                    });
                                }
                                //下一页。
                                if (!isLast) {
                                    p.find("a[class=next]").click(function() {
                                        var i = parseInt(opts.index);
                                        if (i < count) {
                                            opts.index = i + 1;
                                            LoadWorks(opts);
                                        }
                                    });
                                }
                                //任意页。
                                p.find("input[type=button]").click(function() {
                                    var v = p.find("input[type=text]").val();
                                    if (v && (v >= 1 && v <= count)) {
                                        opts.index = parseInt(v);
                                        LoadWorks(opts);
                                    }
                                });
                            }
                        }
                        if (opts.lastLoad) {
                            opts.lastLoad();
                        }
                    } else {
                        $.messager.show({
                            title: "加载作业数据异常！",
                            msg: data.Message
                        });
                    }
                }
            });
        }
    };
    //设置搜索Url条件。
    SetSearchFilter = function(exp) {
        var o = $(".tab_title dt a");
        if (o && exp) {
            var href = o.attr("href");
            if (href.indexOf("?") > 0) {
                href = href.split("?")[0];
            }
            if (exp.length > 0) {
                o.attr("href", href + "?" + exp);
            }
        }
    }
});