//报表
$(function() {
    var type = $("#IndexRpt_type").val();
    var uid = $("#IndexRpt_UID").val();
    var cid = $("#IndexRpt_CID").val();
    var sid = $("#IndexRpt_SID").val();
    var st = $("#IndexRpt_Time").val();
    var unitName = $("#IndexRpt_UnitName").val();
    var className = $("#IndexRpt_ClassName").val();
    var studentID = $("#IndexRpt_StudentID").val();
    var studentName = $("#IndexRpt_StudentName").val();
    var catalogName = $("#IndexRpt_CatalogName").val();
    var cols = [[]], title = "全区报表统计";
    if (uid == null || uid == "") {
        if (type == "catalog") {
            title += "[" + catalogName + "]";
        }
        //全区。
        cols = [[{ field: "UnitName", title: "单位名称", width: 120, align: "left", sortable: true, formatter: function(value, row, index) { return "<a href=\"IndexRpt.aspx?type=unit&uid=" + row.UnitID + "&sid=" + sid + "&st=" + st + "\" target=\"_blank\">" + value + "</a>" }, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "ClassCount", title: "班级数", width: 80, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "StudentCount", title: "学生人数", width: 90, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "WorkCount", title: "作品总数", width: 95, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "SRCount", title: "评语总数", width: 95, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "AvgCount", title: "人均作品数", width: 60, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "Score", title: "评分等第", width: 120, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }]];
    } else {
        title = unitName + "报表统计";
        if (cid == null || cid == "") {
            if (sid && sid != "") {
                title += "[" + catalogName + "]";
            }
            //学校。
            cols = [[{ field: "ClassName", title: "班级名称", width: 120, align: "left", sortable: true, formatter: function(value, row, index) { return "<a href=\"IndexRpt.aspx?uid=" + uid + "&type=class&cid=" + row.ClassID + "&sid=" + sid + "&st=" + st + "\" target=\"_blank\">" + value + "</a>" }, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "StudentCount", title: "学生人数", width: 90, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "WorkCount", title: "作品总数", width: 95, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "SRCount", title: "评语总数", width: 95, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "AvgCount", title: "人均作品数", width: 60, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "Score", title: "评分等第", width: 120, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }]];
        } else {
            title += "(" + className + ")";
            if (studentID == null || studentID == "") {
                cols = [[{ field: "StudentName", title: "学生姓名", width: 120, align: "left", sortable: true, formatter: function(value, row, index) { return "<a href=\"IndexRpt.aspx?uid=" + uid + "&type=student&cid=" + cid + "&StudentID=" + row.StudentID + "&sid=" + sid + "&st=" + st + "\" target=\"_blank\">" + value + "</a>" }, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "WorkCount", title: "提交作品数", width: 90, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "SRCount", title: "评语数", width: 90, align: "right", sortable: true }, { field: "Score", title: "评分等第", width: 120, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }]];
            } else {
                title += studentName;
                cols = [[{ field: "WorkName", title: "作品名称", width: 120, align: "left", sortable: true, formatter: function(value, row, index) { return "<a href=\"IndexDetails.aspx?WorkID=" + row.WorkID + "\" target=\"_blank\">" + value + "</a>"; }, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "ReviewValue", title: "评分", width: 100, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "SRCount", title: "评语", width: 100, align: "center", sortable: true, formatter: function(value, row, index) { return value > 0 ? "有" : "无" }, styler: function(value, row, index) { return "vertical-align:middle;"; } }, { field: "CreateTime", title: "上传时间", width: 100, align: "right", sortable: true, styler: function(value, row, index) { return "vertical-align:middle;"; } }]];
            }
            //班级。
            if (sid && sid != "") {
                title += "[" + catalogName + "]";
            }
        }
    }
    $(".part_title").html(title);
    $(".part_title").attr("title", title);
    setWorkTime(st);
    //加载数据。
    $("#IndexRpt_Rpt").datagrid({
        url: "IndexData.ashx",
        queryParams: {
            type: "rpt",
            uid: uid,
            cid: cid,
            gid: studentID,
            sid: sid
        },
        height: 500,
        singleSelect: true,
        fitColumns: true,
        pagination: true,
        pageSize: 15,
        pageList: [15, 20, 25, 30],
        rownumbers: true,
        columns: cols,
        toolbar: "#IndexRpt_Rpt_Query"
    });
    //设置时间。
    function setWorkTime(st) {
        if (st && st.length > 0) {
            var start = $("#IndexRpt_txtStartDate"), end = $("#IndexRpt_txtEndDate");
            if (start && end) {
                var strs = st.split("-");
                var d = new Date();
                d.setFullYear(strs[0], parseInt(strs[1]), 1);
                d.setDate(d.getDate() - 1);
                start.datebox("setValue", st + "-01");
                var m = d.getMonth() + 1;
                var date = d.getDate();
                end.datebox("setValue", d.getFullYear() + "-" + (m < 10 ? "0" + m : m) + "-" + (date < 10 ? "0" + date : date));
            }
        }
    };
    //按时间查询。
    SearchLoadData = function() {
        var startObj = $("#IndexRpt_txtStartDate");
        var endObj = $("#IndexRpt_txtEndDate");
        if (startObj && endObj) {
            var result = startObj.datebox("isValid");
            result &= endObj.datebox("isValid");
            if (result) {
                $("#IndexRpt_Rpt").datagrid("load", {
                    type: "rpt",
                    uid: uid,
                    cid: cid,
                    gid: studentID,
                    st: startObj.datebox("getValue") + "|" + endObj.datebox("getValue")
                });
            }
        }
    };
    //按时间加载。
    if (st && st.length > 0) {
        SearchLoadData();
    }
});