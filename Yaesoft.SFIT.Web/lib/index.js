//首页脚本。
$(function() {
    //学校单位ID。
    var uid = "";
    //科目ID。
    var sid = "";
    //时间值。
    var st = "";
    //菜单数据加载事件。
    var typeViewObj = $("#index_typeView a[class=currrent]");
    $("#index_typeView a").on("click", function() {
        uid = sid = st = "";
        typeViewObj.removeClass("currrent");
        $(this).addClass("currrent");
        typeViewObj = $(this);
        loadLeftMenu(typeViewObj);
        $("#newWorkTitle").trigger("click");
    });
    //加载默认菜单数据。
    loadLeftMenu(typeViewObj);
    //加载最新作品数据。
    loadNewWorks(1);
    //加载左边菜单数据。
    function loadLeftMenu(typeViewObj) {
        if (typeViewObj) {
            var typeView = "";
            switch (typeViewObj.attr("id")) {
                case "index_typeView_unit": //按单位。
                    typeView = "unit";
                    $("#index_leftMenu h5[class=trans]").html("学校单位");
                    break;
                case "index_typeView_time": //按时间。
                    typeView = "time";
                    $("#index_leftMenu h5[class=trans]").html("年度月份");
                    break;
                case "index_typeView_catalog": //按册次。
                    typeView = "catalog";
                    $("#index_leftMenu h5[class=trans]").html("课程目录");
                    break;
            }
            loadMenuData({
                type: typeView,
                uid: null,
                cid: null,
                size: 20,
                index: 1,
                fn: function(i, t) {
                    var sname = t.Name;
                    if (sname && sname.length > 15) {
                        sname = sname.substring(0, 15) + "..";
                    }
                    var html = "<dd class=\"clearfix\" value=\"" + t.ID + "\" title=\"" + t.Name + "\">";
                    if (typeView == "unit") {
                        html += "<h6><a href=\"IndexSchool.aspx?UID=" + t.ID + "\" target=\"_blank\">" + sname + "</a></h6>";
                    } else {
                        html += "<h6><a href=\"javascript:void(0)\">" + sname + "</a></h6>";
                    }
                    var p = "uid";
                    if (typeView == "catalog") {
                        p = "sid"
                    } else if (typeView == "time") {
                        p = "st"
                    }
                    html += "<p><a href=\"IndexRpt.aspx?type=" + typeView + "&" + p + "=" + t.ID + "\" target=\"_blank\"><img src=\"Include/formbg.jpg\" alt=\"报表\" /></a></p>";
                    html += "</dd>";
                    return html;
                },
                fnClick: function(obj) {
                    if (typeView == "unit") {
                        uid = obj.attr("value");
                        SetSearchFilter("uid=" + uid);
                    } else if (typeView == "catalog") {
                        sid = obj.attr("value");
                        SetSearchFilter("sid=" + sid);
                    } else if (typeView == "time") {
                        st = obj.attr("value");
                        SetSearchFilter("st=" + st);
                    }
                    $("#newWorkTitle").trigger("click");
                }
            });
        }
    };
    //学生作品集按钮事件。
    //最新作业。
    $("#newWorkTitle").click(function() {
        $(".tab_title dd").removeClass("current");
        $(this).addClass("current");
        $(".hot_works").hide();
        $(".new_works").show();
        //加载数据。
        loadNewWorks(1);
    });
    //加载最新作品数据。
    function loadNewWorks(index) {
        LoadWorks({
            id: "newWork",
            uid: uid,
            cid: null,
            sid: sid,
            st: st,
            size: 12,
            index: index,
            fn: function(i, t) {
                var sname = t.SName;
                if (sname && sname.length > 10) {
                    sname = sname.substring(0, 10) + "..";
                }
                var html = "<li>";
                html += "<a href=\"IndexClasses.aspx?cid=" + t.CID + "&sid=" + t.SID + "\" target=\"_blank\">";
                html += "<span><img src=\"../Include/filebg.jpg\" alt=\"" + sname + "\" /></span>";
                html += "<span class=\"name\"><b>" + t.UName + "</b>" + t.CName + "</span>";
                html += "<span class=\"course\" title=\"" + t.SName + "(" + t.Time + ")\">" + sname + "<em>(" + t.Works + ")</em></span>";
                html += "</a></li>";
                return html;
            }
        });
    };
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
            cid: null,
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
            cid: null,
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