//================================================================================
//  FileName: Tools.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-24
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.TeaHost.Data;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 工具类。
    /// </summary>
    internal static class Tools
    {
        /// <summary>
        /// 设置评阅到界面。
        /// </summary>
        /// <param name="cbb"></param>
        /// <param name="evaluate"></param>
        public static void SetEvaluateToWin(ComboBox cbb, Evaluate evaluate, ToolTipHandler toolTipHandler)
        {
            if (cbb != null && evaluate != null)
            {
                if (evaluate.Type == EnumEvaluateType.Score)
                {
                    if (toolTipHandler != null)
                    {
                        toolTipHandler(cbb, "分数制");
                    }
                    cbb.BeginUpdate();
                    cbb.DropDownStyle = ComboBoxStyle.DropDown;
                    cbb.Text = string.Format("{0}", evaluate.MinValue + 1);
                    cbb.TextChanged += new EventHandler(delegate(object o, EventArgs args)
                    {
                        ComboBox box = o as ComboBox;
                        if (box != null)
                        {
                            try
                            {
                                int result = 0;
                                if (int.TryParse(box.Text.Trim(), out result))
                                {
                                    if (result < evaluate.MinValue || result > evaluate.MaxValue)
                                    {
                                        MessageBox.Show(string.Format("评阅分数无效，须在[{0}-{1}]之间！", evaluate.MinValue, evaluate.MaxValue));
                                        box.Text = string.Format("{0}", evaluate.MinValue);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("评阅分数不能转化为数字！");
                                }
                            }
                            catch (Exception) { }
                        }
                    });
                    cbb.EndUpdate();
                }
                else
                {
                    if (toolTipHandler != null)
                    {
                        toolTipHandler(cbb, "等级制");
                    }
                    cbb.BeginUpdate();
                    cbb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbb.DataSource = evaluate.Items;
                    cbb.DisplayMember = "ItemName";
                    cbb.ValueMember = "ItemValue";
                    cbb.SelectedIndex = -1;
                    cbb.EndUpdate();
                }
            }
        }
        /// <summary>
        /// 获取评阅数据。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="cbb"></param>
        /// <param name="txtSubjectiveReviews"></param>
        /// <returns></returns>
        public static LocalWorkReview GetEvaluateFromWin(LocalStudentWorkStore store, ComboBox cbb, TextBox txtSubjectiveReviews)
        {
            if (store != null && cbb != null && txtSubjectiveReviews != null)
            {
                LocalWorkReview result = new LocalWorkReview();
                result.TeacherID = store.TeacherID;
                result.TeacherName = store.TeacherName;
                result.SubjectiveReviews = txtSubjectiveReviews.Text.Trim();
                if (store.Evaluate.Type == EnumEvaluateType.Hierarchy)
                {
                    result.ReviewValue = string.Format("{0}", cbb.SelectedValue);
                }
                else
                {
                    int val = -1;
                    if (int.TryParse(cbb.Text, out val))
                    {
                        if (val < store.Evaluate.MinValue || val > store.Evaluate.MaxValue)
                        {
                            MessageBox.Show(string.Format("评阅分数无效，须在[{0}-{1}]之间！", store.Evaluate.MinValue, store.Evaluate.MaxValue));
                        }
                    }
                    if (val < store.Evaluate.MinValue)
                    {
                        val = store.Evaluate.MinValue;
                    }
                    result.ReviewValue = string.Format("{0}", val);
                }
                if (!string.IsNullOrEmpty(result.ReviewValue))
                {
                    return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="bchecked"></param>
        public static void SetTreeNodeCheckedStatus(TreeNode node, bool bchecked)
        {
            if (node != null)
            {
                node.Checked = bchecked;
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    foreach (TreeNode n in node.Nodes)
                    {
                        SetTreeNodeCheckedStatus(n, bchecked);
                    }
                }
            }
        }

        /// <summary>
        /// 恢复作业关联。
        /// </summary>
        public static void RecoveryWorkAssociation(ref LocalStudentWorkStore store, string studentId)
        {
            if (store == null || store.Students == null || store.Students.Count == 0 || string.IsNullOrEmpty(studentId)) return;
            LocalStudent ls = store.Students[studentId];
            if (ls == null || ls.HasWork()) return;
            string dir = Path.GetFullPath(string.Format("{0}/{1}", store.RootDir(), ls.StudentID));
            if (!Directory.Exists(dir)) return;
            FileInfo[] files = new DirectoryInfo(dir).GetFiles();
            if (files == null || files.Length == 0) return;

            ls.Work = new LocalStudentWork();
            ls.Work.WorkID = Guid.NewGuid().ToString().Replace("-", "");
            ls.Work.WorkName = store.CatalogName;
            ls.Work.UploadIP = "127.0.0.1";
            ls.Work.Type = EnumWorkType.Public;
            ls.Work.Time = DateTime.Now;
            ls.Work.Status = EnumWorkStatus.Recive | EnumWorkStatus.Submit;
            ls.Work.Description = new CDATA();
            ls.Work.WorkFiles = new LocalStudentWorkFiles();

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Exists)
                {
                    LocalStudentWorkFile file = new LocalStudentWorkFile();
                    file.FileID = Path.GetFileNameWithoutExtension(files[i].Name);
                    file.FileName = ls.Work.WorkName + "_" + (i + 1);
                    file.FileExt = files[i].Extension;
                    file.Size = files[i].Length;

                    if (ls.Work.FileExt == null)
                        ls.Work.FileExt = file.FileExt;
                    else if (ls.Work.FileExt.IndexOf(file.FileExt) == -1)
                        ls.Work.FileExt += string.Format("|{0}", file.FileExt);

                    ls.Work.WorkFiles.Add(file);
                }
            }
        }
    }
}