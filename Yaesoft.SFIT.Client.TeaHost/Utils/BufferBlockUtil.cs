//================================================================================
//  FileName: BigBlockDataUtil.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-27
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

namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 大块数据工具类。
    /// </summary>
    internal class BufferBlockUtil : IDisposable
    {
        #region 成员变量，构造函数。
        long totoal = 0;
        Queue<byte[]> queue = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public BufferBlockUtil()
        {
            this.queue = new Queue<byte[]>();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void Write(byte[] array, int offset, int count)
        {
            lock (this)
            {
                int len = 0;
                if (array != null && (len = array.Length) > 0)
                {
                    if ((offset > -1) && (offset < len) && (count > 0) && ((offset + count) <= len))
                    {
                        byte[] buf = new byte[count];
                        Array.Copy(array, offset, buf, 0, count);
                        this.queue.Enqueue(buf);
                        this.totoal += buf.Length;
                    }

                }
            }
        }

        /// <summary>
        /// 将数据转换为数组。
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            lock (this)
            {
                if (this.totoal > 0 && this.queue.Count > 0)
                {
                    byte[] result = new byte[this.totoal];
                    long index = 0;
                    while (this.queue.Count > 0)
                    {
                        byte[] data = this.queue.Dequeue();
                        int len = 0;
                        if ((len = data.Length) > 0)
                        {
                            Array.Copy(data, 0, result, index, len);
                            index += len;
                        }
                    }
                    return result;
                }
                return null;
            }
        }


        #region IDisposable 成员
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.queue = null;
            this.totoal = 0;
        }

        #endregion
    }
}
