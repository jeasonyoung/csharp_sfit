//搜索界面。
$(function() {
    //默认显示查询结果数据。
    $(".hot_works").show();
    var uid = $(".searchbar input[name=txtUnitName]");
    var cid = $(".searchbar input[name=txtClassName]");
    var sid = $(".searchbar input[name=txtCatalogName]");
    var start = $("#txtStartDate");
    var end = $("#txtEndDate");
    var uname = $("#indexSearch_queryVal input[name=uname]").val();
    if (uname && uname.length > 0) {
        uid.val(uname);
    }
    var cname = $("#indexSearch_queryVal input[name=cname]").val();
    if (cname && cname.length > 0) {
        cid.val(cname);
    }
    var sname = $("#indexSearch_queryVal input[name=sname]").val();
    if (sname && sname.length > 0) {
        sid.val(sname);
    }
    var st = $("#indexSearch_queryVal input[name=st]").val();
    if (st && st.length > 0) {
        var strs = st.split("-");
        var d = new Date();
        d.setFullYear(strs[0], parseInt(strs[1]), 1);
        d.setDate(d.getDate() - 1);
        start.datebox("setValue", st + "-01");
        var m = d.getMonth() + 1;
        var date = d.getDate();
        end.datebox("setValue", d.getFullYear() + "-" + (m < 10 ? "0" + m : m) + "-" + (date < 10 ? "0" + date : date));
    }
    //提交事件。
    $("#indexSearch_Submit").on("click", function() {
        var result = uid.validatebox("isValid");
        result &= cid.validatebox("isValid");
        result &= sid.validatebox("isValid");
        result &= start.datebox("isValid");
        result &= end.datebox("isValid");
        if (result) {
            var startValue = start.datebox("getValue");
            var endValue = end.datebox("getValue");

            //加载数据。
            LoadWorks({
                id: "indexSearch_resultList",
                type: "search",
                uid: uid.val(),
                cid: cid.val(),
                sid: sid.val(),
                st: startValue + "|" + endValue,
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
                    $("#indexSearch_resultList img").lazyload({
                        placeholder: "../Include/ar01.jpg",
                        threshold: 200,
                        effect: "fadeIn"
                    });
                }
            });
        }
    });
    //默认加载数据。
    $("#indexSearch_Submit").trigger("click");
})