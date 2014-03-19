//班级主页
$(function() {
    //学校ID。
    var uid = $("#index_typeView input[name=UID]").val();
    //年级ID。
    var gid = $("#index_typeView input[name=GID]").val();
    //班级ID。
    var cid = $("#index_typeView input[name=CID]").val();
    //课程ID。
    var sid = $("#index_typeView input[name=SID]").val();
    //时间值。
    var st = "";
    var isFirst = true;
    //菜单数据加载事件。
    var typeViewObj = $("#index_typeView a[class=currrent]");
    $("#index_typeView a").on("click", function() {
        sid = "";
        typeViewObj.removeClass("currrent");
        $(this).addClass("currrent");
        typeViewObj = $(this);
        loadLeftMenu(typeViewObj);
        loadNewWorks(1);
    });
    //加载默认菜单数据。
    loadLeftMenu(typeViewObj);
    //默认加载最新作品。
    loadNewWorks(1);
    //加载左边菜单数据。
    function loadLeftMenu(typeViewObj) {
        if (typeViewObj) {
            var typeView = "";
            switch (typeViewObj.attr("id")) {
                case "index_typeView_time": //按时间。
                    typeView = "time";
                    $("#index_leftMenu h5[class=trans]").attr("title", "年度月份");
                    break;
                case "index_typeView_catalog": //按册次。
                    typeView = "catalog";
                    $("#index_leftMenu h5[class=trans]").attr("title", "课程目录");
                    break;
            }
            loadMenuData({
                type: typeView,
                uid: uid,
                cid: cid,
                gid: gid,
                size: 20,
                index: 1,
                fn: function(i, t) {
                    var sname = t.Name;
                    if (sname && sname.length > 13) {
                        sname = sname.substring(0, 13) + "..";
                    }
                    var html = "<dd class=\"clearfix\" value=\"" + t.ID + "\" title=\"" + t.Name + "\">";
                    html += "<h6><a href=\"javascript:void(0)\">" + sname + "</a></h6>";
                    var p = "cid";
                    if (typeView == "catalog") {
                        p = "sid"
                    } else if (typeView == "time") {
                        p = "st"
                    }
                    html += "<p><a href=\"IndexRpt.aspx?uid=" + uid + "&type=" + typeView + "&" + p + "=" + t.ID + "\" target=\"_blank\"><img src=\"Include/formbg.jpg\" alt=\"报表\" /></a></p>";
                    html += "</dd>";
                    return html;
                },
                fnClick: function(obj) {
                    if (typeView == "catalog") {
                        sid = obj.attr("value");
                        SetSearchFilter("cid=" + cid + "&sid=" + sid);
                    } else if (typeView == "time") {
                        st = obj.attr("value");
                        SetSearchFilter("cid=" + cid + "&st=" + st);
                    }
                    $("#allWorkTitle").html("全部作品");
                    $("#allWorkTitle").trigger("click");
                },
                fnLoad: function(obj) {
                    if (sid && sid != "" && isFirst && obj) {
                        var s = obj.find("dd[value=" + sid + "]");
                        if (s && s.length > 0) {
                            isFirst = false;
                            s.trigger("click");
                        } else {
                            //翻页处理。
                            var p = obj.next(".sidebar_page");
                            if (p) {
                                var next = p.find(".nextpage");
                                if (next) {
                                    var nextPrev = next.find("a");
                                    if (nextPrev && nextPrev.length > 0) {
                                        nextPrev.trigger("click");
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    };
    //加载最新作品数据。
    function loadNewWorks(index) {
        $("#allWorkTitle").html("最新作品");
        LoadWorks({
            id: "allWork",
            type: "newWork",
            uid: uid,
            cid: cid,
            sid: null,
            st: st,
            size: 12,
            index: index,
            fn: function(i, t) {
                var sname = t.SName;
                if (sname && sname.length > 10) {
                    sname = sname.substring(0, 10) + "..";
                }
                var html = "<li>";
                html += "<a href=\"IndexClasses.aspx?cid=" + t.CID + "&sid=" + t.SID + "\" target=\"_self\">";
                html += "<span><img src=\"../Include/filebg.jpg\" alt=\"" + sname + "\" /></span>";
                html += "<span class=\"name\"><b>" + t.UName + "</b>" + t.CName + "</span>";
                html += "<span class=\"course\" title=\"" + t.SName + "(" + t.Time + ")\">" + sname + "<em>(" + t.Works + ")</em></span>";
                html += "</a></li>";
                return html;
            }
        });
    };
    //学生作品集按钮事件。
    //全部作业。
    $("#allWorkTitle").click(function() {
        $(".tab_title dd").removeClass("current");
        $(this).addClass("current");
        $(".hot_works").hide();
        $(".new_works").show();
        //加载数据。
        LoadWorks({
            id: "allWork",
            uid: uid,
            cid: cid,
            sid: sid,
            st: st,
            size: 12,
            index: 1,
            fn: function(i, t) {
                var wname = t.Name;
                if (wname && wname.length > 13) {
                    wname = wname.substring(0, 13) + "..";
                }
                var str = t.Value;
                if (t.SubRev && t.SubRev != "") {
                    str += "\n主观评语：\n" + t.SubRev;
                }
                var html = "<li><a href=\"IndexDetails.aspx?WorkID=" + t.ID + "\" target=\"_blank\" title=\"" + str + "\">";
                html += "<span class=\"pic\"><img src=\"WorkThumbnails.ashx?id=" + t.ID + "&w=200&h=133\" alt=\"" + wname + "\" /></span>";
                html += "<span class=\"name\"><b>" + t.UName + "</b><b>" + t.CName + "</b>" + t.StuName + "</span>";
                html += "<span class=\"course\" title=\"" + t.Name + "[" + t.Time + "]\">" + wname + "</span>";
                html += "</a></li>";
                return html;
            },
            lastLoad: function() {
                $("#allWork img").lazyload({
                    placeholder: "../Include/ar01.jpg",
                    threshold: 200,
                    effect: "fadeIn"
                });
            }
        });
    });
    //点击率最高作业。
    $("#hotWorkTitle").click(function() {
        $(".tab_title dd").removeClass("current");
        $(this).addClass("current");
        $(".new_works").hide();
        $(".hot_works").hide();
        $("#hotWork").show();
        //加载点击率最高数据。
        LoadWorks({
            id: "hotWork",
            uid: uid,
            cid: cid,
            sid: sid,
            st: st,
            size: 9,
            index: 1,
            fn: function(i, t) {
                var wname = t.WName;
                if (wname && wname.length > 10) {
                    wname = wname.substring(0, 10) + "..";
                }
                var html = "<li><a href=\"IndexDetails.aspx?WorkID=" + t.WID + "\" target=\"_blank\">";
                html += "<span class=\"pic\"><img src=\"WorkThumbnails.ashx?id=" + t.WID + "&w=200&h=133\" alt=\"" + t.WName + "\" /></span>";
                html += "<span class=\"name\"><b>" + t.UName + "</b><b>" + t.CName + "</b>" + t.SName + "<em style=\"color:red;\">(" + t.Hits + ")</em></span>";
                html += "<span class=\"course\" title=\"" + t.WName + "\">" + wname + "</span>";
                html += "<span class=\"name\">" + t.Time + "</span>";
                html += "</a></li>";
                return html;
            },
            lastLoad: function() {
                $("#hotWork img").lazyload({
                    placeholder: "../Include/ar01.jpg",
                    threshold: 200,
                    effect: "fadeIn"
                });
            }
        });
    });
    //最优作业。
    $("#bestWorkTitle").click(function() {
        $(".tab_title dd").removeClass("current");
        $(this).addClass("current");
        $(".new_works").hide();
        $(".hot_works").hide();
        $("#bestWork").show();
        //加载最优作业数据。
        LoadWorks({
            id: "bestWork",
            uid: uid,
            cid: cid,
            sid: sid,
            st: st,
            size: 9,
            index: 1,
            fn: function(i, t) {
                var wname = t.WName;
                if (wname && wname.length > 10) {
                    wname = wname.substring(0, 10) + "..";
                }
                var html = "<li><a href=\"IndexDetails.aspx?WorkID=" + t.WID + "\" target=\"_blank\">";
                html += "<span class=\"pic\"><img src=\"WorkThumbnails.ashx?id=" + t.WID + "&w=200&h=133\" alt=\"" + t.WName + "\" /></span>";
                html += "<span class=\"name\" title=\"" + t.SubRev + "\"><b>" + t.UName + "</b><b>" + t.CName + "</b>" + t.SName + "<em style=\"color:red;\">(" + t.Value + ")</em></span>";
                html += "<span class=\"course\" title=\"" + t.WName + "\">" + wname + "</span>";
                html += "<span class=\"name\">" + t.Time + "</span>";
                html += "</a></li>";
                return html;
            },
            lastLoad: function() {
                $("#bestWork img").lazyload({
                    placeholder: "../Include/ar01.jpg",
                    threshold: 200,
                    effect: "fadeIn"
                });
            }
        });
    });
});