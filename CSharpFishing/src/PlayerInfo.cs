using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main_interface
{
    class PlayerInfo
    {
        private string _teamname = "";
        /// <summary>
        /// 团队名
        /// </summary>
        public string Teamname
        {
            get { return _teamname; }
            set { _teamname = value; }
        }
        private string _peoplename = "";

        public string Peoplename
        {
            get { return _peoplename; }
            set { _peoplename = value; }
        }
        private string _sexname = "";

        public string Sexname
        {
            get { return _sexname; }
            set { _sexname = value; }
        }
        private string _crdname = "";

        public string Crdname
        {
            get { return _crdname; }
            set { _crdname = value; }
        }
        private string _phonename = "";

        public string Phonename
        {
            get { return _phonename; }
            set { _phonename = value; }
        }
        private string _money = null;

        public string Money
        {
            get { return _money; }
            set { _money = value; }
        }
        private bool _isCome = false;

        public bool IsCome
        {
            get { return _isCome; }
            set { _isCome = value; }
        }
        private int _competitionNum = 0;

        public int CompetitionNum
        {
            get { return _competitionNum; }
            set { _competitionNum = value; }
        }
    }
}
