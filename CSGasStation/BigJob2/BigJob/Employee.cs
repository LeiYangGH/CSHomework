using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigJob
{
    class Employee
    {
        AccessHelper data = new AccessHelper();

        //定义工程师--数据结构
        private string id = "";
        private string fullname = "";
        private string sex = "";
        private string dept = "";
        private string tel = "";
        private string memo = "";

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        //添加信息
        public int AddEmployee(Employee employee)
        {
            OleDbParameter[] prams = {
                                        data.MakeInParam("@id",  OleDbType.VarChar, 20,employee.Id),
                                        data.MakeInParam("@fullname",  OleDbType.VarChar, 20,employee.FullName),
                                        data.MakeInParam("@sex",  OleDbType.VarChar, 4, employee.Sex),
                                        data.MakeInParam("@dept",  OleDbType.VarChar, 20, employee.Dept),
                                        data.MakeInParam("@tel", OleDbType.VarChar, 20, employee.Tel),
                                        data.MakeInParam("@memo", OleDbType.VarChar, 200, employee.Memo),
            };
            return (AccessHelper.ExecuteNonQuery("INSERT INTO S_engineer(Eng_code,Eng_name,Eng_sex,Eng_dept,Eng_tel,Eng_memo) VALUES (@id,@fullname,@sex,@dept,@tel,@memo)", prams));

        }

        //查询
        public DataSet GetAllEmployee()
        {
            return (AccessHelper.ExecuteDataSet("select * from S_engineer order by Eng_code", null));
        }

        //根据姓名查询
        public DataSet FindEmployeeByFullName(Employee p)
        {
            OleDbParameter[] parms ={
            data .MakeInParam ("@fullname",OleDbType .VarChar ,20,p.FullName+'%' ),
            };
            return (AccessHelper.ExecuteDataSet("select * from S_engineer where Eng_name like @fullname order by Eng_code", parms));
        }


        //根据员工部门查询所有员工信息
        public DataSet FindEmployeeByDept(Employee p)
        {
            OleDbParameter[] parms ={
            data .MakeInParam ("@dept",OleDbType .VarChar ,20,p.Dept +'%' ),
            };
            return (AccessHelper.ExecuteDataSet("select * from S_engineer where Eng_dept like @dept order by Eng_code", parms));
        }

        //删除员工信息
        public int DeleteEmployee(Employee p)
        {
            OleDbParameter[] parms ={
            data .MakeInParam ("@id",OleDbType .Integer ,4,p.Id ),
            };
            return (AccessHelper.ExecuteNonQuery("delete  from S_engineer where Eng_code=@id", parms));
        }

        //修改员工信息
        public int UpdateEmployee(Employee p)
        {
            OleDbParameter[] parms ={

                data.MakeInParam("@fullname",  OleDbType.VarChar, 20,p.FullName),
                                        data.MakeInParam("@sex",  OleDbType.VarChar, 4, p.Sex),
                                        data.MakeInParam("@dept",  OleDbType.VarChar, 20, p.Dept),
                                        data.MakeInParam("@tel", OleDbType.VarChar, 20, p.Tel),
                                        data.MakeInParam("@memo", OleDbType.VarChar, 200, p.Memo),
                data .MakeInParam ("@id",OleDbType .VarChar ,4,p.Id ),
            };
            return (AccessHelper.ExecuteNonQuery("update S_engineer set Eng_code=@id,Eng_name=@fullname,Eng_sex=@sex,Eng_dept=@dept,Eng_tel=@tel,Eng_memo=@memo  where Eng_code=@id", parms));
        }

    }
}
