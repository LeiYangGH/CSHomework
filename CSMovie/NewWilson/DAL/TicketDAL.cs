﻿using Model;
using Model.critical;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class TicketDAL
    {
        public Ticket FromSqlDataReader(SqlDataReader reader)
        {
            Ticket obj = new Ticket();
            if (reader["positionId"] is DBNull == false)
            {
                obj.PositionId = Convert.ToInt32(reader["positionId"]);
            }
            if (reader["customerTypeId"] is DBNull == false)
            {
                obj.CustomerTypeId = Convert.ToByte(reader["customerTypeId"]);
            }
            if (reader["sellPrice"] is DBNull == false)
            {
                obj.SellPrice = Convert.ToDecimal(reader["sellPrice"]);
            }
            if (reader["sellDateTime"] is DBNull == false)
            {
                obj.SellDateTime = Convert.ToDateTime(reader["sellDateTime"]);
            }
            if (reader["playId"] is DBNull == false)
            {
                obj.PlayId = Convert.ToString(reader["playId"]);
            }
            if (reader["scheduleName"] is DBNull == false)
            {
                obj.ScheduleName = Convert.ToString(reader["scheduleName"]);
            }
            if (reader["scheduleid"] is DBNull == false)
            {
                obj.Scheduleid = Convert.ToInt32(reader["scheduleid"]);
            }
            if (reader["movieName"] is DBNull == false)
            {
                obj.MovieName = Convert.ToString(reader["movieName"]);
            }
            if (reader["movieId"] is DBNull == false)
            {
                obj.MovieId = Convert.ToString(reader["movieId"]);
            }
            if (reader["playDate"] is DBNull == false)
            {
                obj.PlayDate = Convert.ToDateTime(reader["playDate"]);
            }
            if (reader["playBeginTime"] is DBNull == false)
            {
                obj.PlayBeginTime = Convert.ToDateTime(reader["playBeginTime"]);
            }
            if (reader["hallId"] is DBNull == false)
            {
                obj.HallId = Convert.ToInt16(reader["hallId"]);
            }
            if (reader["hallName"] is DBNull == false)
            {
                obj.HallName = Convert.ToString(reader["hallName"]);
            }
            if (reader["rowNum"] is DBNull == false)
            {
                obj.RowNum = Convert.ToInt32(reader["rowNum"]);
            }
            if (reader["colNum"] is DBNull == false)
            {
                obj.ColNum = Convert.ToInt32(reader["colNum"]);
            }
            if (reader["positionTypeName"] is DBNull == false)
            {
                obj.PositionTypeName = Convert.ToString(reader["positionTypeName"]);
            }
            if (reader["positionTypeId"] is DBNull == false)
            {
                obj.PositionTypeId = Convert.ToByte(reader["positionTypeId"]);
            }
            return obj;
        }

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
        public List<Ticket> Search(TicketCritical ticketCritical)
        {
            throw new NotImplementedException();
        }
    }
}
