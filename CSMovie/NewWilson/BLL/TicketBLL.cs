﻿using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class TicketBLL
    {
        public List<Ticket> GetAllTicket()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 插入一个售票记录
        /// </summary>
        /// <param name="ticket"></param>
        public void Insert(Ticket ticket)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 此功能目前可不实现
        /// </summary>
        /// <param name="ticket"></param>
        public void Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 日前可不实现
        /// </summary>
        /// <param name="ticket"></param>
        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 复杂条件下的 票  匹配   本次售票系统未涉及票统计, 可不实现
        /// </summary>
        /// <param name="ticket"></param>
        public List<Ticket> Search(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}