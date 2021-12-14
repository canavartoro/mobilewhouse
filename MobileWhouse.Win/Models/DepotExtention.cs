using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;
using MobileWhouse.Log;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Models
{
    internal class DepotExtention
    {
        public DepotExtention(Depot depo)
        {
            GetLocationInfo(depo.Id);
        }

        private int _input_location_id = 0;
        private int _output_location_id = 0;
        private bool _is_location_track = false;

        public int input_location_id
        {
            get { return _input_location_id; }
            set { _input_location_id = value; }
        }

        public int output_location_id
        {
            get { return _output_location_id; }
            set { _output_location_id = value; }
        }

        public bool is_location_track
        {
            get { return _is_location_track; }
            set { _is_location_track = value; }
        }

        private void GetLocationInfo(int depoid)
        {
            try
            {
                Screens.ShowWait();

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat("SELECT wh.bwh_input_location_id,wh.bwh_output_location_id,wh.is_location_track,wh.isqualty_whouse FROM uyumsoft.invd_branch_whouse wh WHERE co_id = ",
                    ClientApplication.Instance.ClientToken.CoId, " AND branch_id = ",
                    ClientApplication.Instance.ClientToken.BranchId, " AND whouse_id = ", depoid);
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            _input_location_id = StringUtil.ToInteger(res.Value.Rows[0][0]);
                            _output_location_id = StringUtil.ToInteger(res.Value.Rows[0][1]);
                            _is_location_track = StringUtil.ToInteger(res.Value.Rows[0][2]) == 1;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
            }
        }
    }
}
