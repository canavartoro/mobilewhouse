using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using UstunWebService.Models;
using UstunWebService.UTerminalService;

namespace UstunWebService.Helpers
{
    public class PackageHelper
    {
        public const int AMBALAJ_TRANSFER = 3;
        public const int AMBALAJ_SAYIM = 4;
        public const int AMBALAJ_COZ = 5;
        public const int AMBALAJ_BUL = 6;
        public const int AMBALAJLARI_AL = 7;
        public const int COZ_DEPO = 8;
        public const int AMBALAJ_OLUSTUR = 9;

        UTerminalService.UTerminalServices utermserv = null;
        public PackageHelper(UTerminalService.UTerminalServices utermservice)
        {
            this.utermserv = utermservice;
        }

        public ServiceResult<List<PackageDetailModel>> GetPackageInfo(string userName, string password, int whouseId, string packageNo)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            List<PackageDetailModel> resp = null;
            UTerminalService.ServiceRequestOfItemPickingParam param = new UTerminalService.ServiceRequestOfItemPickingParam();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = userName;
            param.Token.Password = password;
            param.Value = new UTerminalService.ItemPickingParam();
            param.Value.PackageNo = packageNo;
            param.Value.WhouseId = whouseId;

            UTerminalService.ServiceResultOfPackageDetail result = utermserv.GetPackageInfo(param);
            if (result != null)
            {
                //Logger.WriteFileLog(new StringBuilder().Append("Ambalaj bilgisi:").Append("Detay:").Append(Logger.ToXml(result)).ToString());
                res.Success = result.Result;
                if (result.Result)
                {
                    resp = new List<PackageDetailModel>();
                    PackageDetailModel packageInf = new PackageDetailModel();
                    packageInf.PackageNo = result.Value.PackageNo;
                    packageInf.PackageMId = result.Value.PackageDId;
                    packageInf.PackageDId = result.Value.PackageDId;
                    packageInf.Qty = result.Value.Qty;
                    packageInf.UnitId = result.Value.UnitId;
                    packageInf.LotId = result.Value.LotId;
                    //packageInf.LotCode = result.Value.LotCode;
                    packageInf.ColorId = result.Value.ColorId;
                    packageInf.ColorCode = result.Value.ColorCode;
                    packageInf.QualityId = result.Value.QualityId;
                    packageInf.QualityCode = result.Value.QualityCode;
                    packageInf.ItemAttribute1Id = result.Value.ItemAttribute1;
                    packageInf.ItemAttribute1Code = result.Value.ItemAttribute1Code;
                    packageInf.ItemAttribute2Id = result.Value.ItemAttribute2;
                    packageInf.ItemAttribute2Code = result.Value.ItemAttribute2Code;
                    packageInf.ItemAttribute3Id = result.Value.ItemAttribute3;
                    packageInf.ItemAttribute3Code = result.Value.ItemAttribute3Code;
                    if (result.Value.ItemInfo != null)
                    {
                        packageInf.ItemId = result.Value.ItemInfo.Id;
                    }
                    resp.Add(packageInf);
                }
                res.ErrorMessage = result.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = resp;
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> CreatePackageTraMTransfer(Token token, int whouseId, int whouse2Id, DateTime docDate, string docNo, List<PackageDetailModel> packageList)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            UTerminalService.ServiceRequestOfInPacKageTraM param = new UTerminalService.ServiceRequestOfInPacKageTraM();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.BranchId = token.BranchId;
            param.Token.CoId = token.CoId;
            param.Value = new UTerminalService.InPacKageTraM();
            param.Value.DepotId = whouseId;
            param.Value.Depo2Id = whouse2Id;
            param.Value.DocDate = docDate.Date;
            param.Value.DocNo = docNo;
            List<UTerminalService.InPacKageD> packageDList = new List<UTerminalService.InPacKageD>();
            for (int i = 0; i < packageList.Count; i++)
            {
                UTerminalService.InPacKageD inpackageD = new UTerminalService.InPacKageD();
                inpackageD.LineNo = (i + 1) * 10;
                inpackageD.LotId = packageList[i].LotId;
                inpackageD.ItemId = packageList[i].ItemId;
                inpackageD.PackageMId = packageList[i].PackageMId;
                inpackageD.PackageDetailType = 1;
                inpackageD.PackageMNo = packageList[i].PackageNo;
                inpackageD.Qty = packageList[i].Qty;
                inpackageD.UnitId = packageList[i].UnitId;
                packageDList.Add(inpackageD);
            }
            param.Value.PacKageDList = packageDList.ToArray();
            UTerminalService.ServiceResultOfPackageInfo response = utermserv.CreatePackageTraMTransfer(param);
            if (response != null)
            {
                res.Success = response.Result;
                res.ErrorMessage = response.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = new List<PackageDetailModel>();
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> CreatePackageTraM(Token token, int whouseId, int whouse2Id, DateTime docDate, string docNo, PackageDetailModel packageM, List<PackageDetailModel> packageList)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            UTerminalService.ServiceRequestOfInPacKageTraM param = new UTerminalService.ServiceRequestOfInPacKageTraM();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.BranchId = token.BranchId;
            param.Token.CoId = token.CoId;
            param.Value = new UTerminalService.InPacKageTraM();
            param.Value.DepotId = whouseId;
            param.Value.Depo2Id = whouse2Id;
            param.Value.DocDate = docDate.Date;
            param.Value.DocNo = docNo;
            param.Value.IsDocNoCreateAuto = true;
            param.Value.Note1 = packageM.Note;

            InPacKageTraM_MoreInfo pacKageTraMMoreInfo = new InPacKageTraM_MoreInfo();
            pacKageTraMMoreInfo.ColorId = packageM.ColorId;
            pacKageTraMMoreInfo.ItemAttribute1Id = packageM.ItemAttribute1Id;
            pacKageTraMMoreInfo.ItemAttribute2Id = packageM.ItemAttribute2Id;
            pacKageTraMMoreInfo.ItemAttribute3Id = packageM.ItemAttribute3Id;
            pacKageTraMMoreInfo.LotId = packageM.LotId;
            pacKageTraMMoreInfo.ItemId = packageM.ItemId;
            pacKageTraMMoreInfo.PackageTypeId = packageM.PackageTypeId;
            pacKageTraMMoreInfo.QualityId = packageM.QualityId;

            pacKageTraMMoreInfo.SetOperationType = true;
            pacKageTraMMoreInfo.PackageOperationType = 2; // Palet
            pacKageTraMMoreInfo.IsNotTransfer = true;
            pacKageTraMMoreInfo.ReadDocTraIdType = 2; //Ambalaj Giriş


            List < UTerminalService.InPacKageD > packageDList = new List<UTerminalService.InPacKageD>();
            for (int i = 0; i < packageList.Count; i++)
            {

                InPacKageD_MoreInfo pacKageDMoreInfo = new InPacKageD_MoreInfo();
                pacKageDMoreInfo.ColorId = packageList[i].ColorId;
                pacKageDMoreInfo.ItemAttribute1Id = packageList[i].ItemAttribute1Id;
                pacKageDMoreInfo.ItemAttribute2Id = packageList[i].ItemAttribute2Id;
                pacKageDMoreInfo.ItemAttribute3Id = packageList[i].ItemAttribute3Id;
                pacKageDMoreInfo.PackageTypeId = packageList[i].PackageTypeId;
                pacKageDMoreInfo.QualityId = packageList[i].QualityId;
                pacKageDMoreInfo.NetWeight = packageList[i].NetWeight;
                pacKageDMoreInfo.GrossWeight = packageList[i].GrossWeight;
                pacKageDMoreInfo.QtyFreePrm = packageList[i].QtyFreePrm;
                pacKageDMoreInfo.FreePrmMId = packageList[i].FreePrmMId;

                UTerminalService.InPacKageD inpackageD = new UTerminalService.InPacKageD();
                inpackageD.LineNo = (i + 1) * 10;
                inpackageD.LotId = packageList[i].LotId;
                inpackageD.ItemId = packageList[i].ItemId;
                inpackageD.PackageMId = packageList[i].PackageMId;
                inpackageD.PackageDetailType = 1;
                inpackageD.PackageMNo = packageList[i].PackageNo;
                inpackageD.Qty = packageList[i].Qty;
                inpackageD.UnitId = packageList[i].UnitId;

                inpackageD.MoreInfo = pacKageDMoreInfo;

                packageDList.Add(inpackageD);
            }
            param.Value.PacKageDList = packageDList.ToArray();
            UTerminalService.ServiceResultOfPackageInfo response = utermserv.CreatePackageTraMTransfer(param);
            if (response != null)
            {
                res.Success = response.Result;
                res.ErrorMessage = response.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = new List<PackageDetailModel>();
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> CreatePackageCycleCountM(Token token, int whouseId, string docNo, DateTime docDate, string note, List<PackageDetailModel> packageList)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            UTerminalService.ServiceRequestOfPackageCycleCountMParam param = new UTerminalService.ServiceRequestOfPackageCycleCountMParam();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.BranchId = token.BranchId;
            param.Token.CoId = token.CoId;
            param.Value = new UTerminalService.PackageCycleCountMParam();
            param.Value.WhouseId = whouseId;
            param.Value.DocDate = docDate.Date;
            param.Value.DocNo = docNo;
            //param.Value.NoteLarge = note;
            List<UTerminalService.PackageCycleCountDParam> packageDList = new List<UTerminalService.PackageCycleCountDParam>();
            for (int i = 0; i < packageList.Count; i++)
            {
                UTerminalService.PackageCycleCountDParam inpackageD = new UTerminalService.PackageCycleCountDParam();
                inpackageD.BwhLocationId = packageList[i].LocationId;
                inpackageD.PackageNo = packageList[i].PackageNo;
                packageDList.Add(inpackageD);
            }
            param.Value.PackageCycleCountlist = packageDList.ToArray();
            UTerminalService.ServiceResultOfInt32 response = utermserv.CreatePackageCycleCountM(param);
            if (response != null)
            {
                res.Success = response.Result;
                res.ErrorMessage = response.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = new List<PackageDetailModel>();
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> RevortPackage(string username, string password, int whouseId, int packageMId, string packageNo)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            UTerminalService.ServiceRequestOfPackageDetail param = new UTerminalService.ServiceRequestOfPackageDetail();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = username;
            param.Token.Password = password;
            param.Value = new UTerminalService.PackageDetail();
            param.Value.WhouseId = whouseId;
            param.Value.PackageMId = packageMId;
            param.Value.PackageNo = packageNo;
            UTerminalService.ServiceResultOfString result = utermserv.RevortPackage(param);
            if (result != null)
            {
                res.Success = result.Result;
                res.ErrorMessage = result.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = new List<PackageDetailModel>();
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> GetPackageMList(Token token, int whouseId, string packageNo)
        {
            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            List<PackageDetailModel> resp = null;
            UTerminalService.ServiceRequestOfInGetPacKageM param = new UTerminalService.ServiceRequestOfInGetPacKageM();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.CoId = token.CoId;
            param.Token.BranchId = token.BranchId;
            param.Value = new UTerminalService.InGetPacKageM();
            param.Value.PackageNo = packageNo;
            param.Value.WhouseId = whouseId;

            UTerminalService.ServiceResultOfListOfOutGetPacKageM result = utermserv.GetPackageMListInfo(param);
            if (result != null)
            {
                //Logger.WriteFileLog(new StringBuilder().Append("Ambalaj bilgisi:").Append("Detay:").Append(Logger.ToXml(result)).ToString());
                res.Success = result.Result;
                if (result.Result)
                {
                    resp = new List<PackageDetailModel>();
                    foreach (var item in result.Value)
                    {
                        PackageDetailModel packageInf = new PackageDetailModel();
                        packageInf.PackageNo = item.PackageMNo;
                        packageInf.PackageMId = item.PackageMId;
                        packageInf.PackageDId = item.PackageMId;
                        packageInf.Qty = item.Qty;
                        packageInf.ItemId = item.ItemId;
                        packageInf.ItemCode = item.ItemCode;
                        packageInf.ItemName = item.ItemName;
                        packageInf.UnitId = item.UnitId;
                        packageInf.UnitCode = item.UnitCode;
                        packageInf.LotId = item.LotId;
                        packageInf.LotCode = item.LotCode;
                        packageInf.ColorId = 0;
                        packageInf.ColorCode = "";
                        packageInf.QualityId = item.QualityId;
                        packageInf.QualityCode = item.QualityCode;
                        packageInf.ItemAttribute1Id = 0;
                        packageInf.ItemAttribute1Code = "";
                        packageInf.ItemAttribute2Id = 0;
                        packageInf.ItemAttribute2Code = "";
                        packageInf.ItemAttribute3Id = 0;
                        packageInf.ItemAttribute3Code = "";
                        packageInf.Selected = true;
                        resp.Add(packageInf);
                    }
                }
                res.ErrorMessage = result.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = resp;
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> GetRevortDepots()
        {
            ServiceResult<List<PackageDetailModel>> serviceResult = new ServiceResult<List<PackageDetailModel>>();
            var revortDepotsfile = HttpContext.Current.Server.MapPath($"~/RevortDepots.ini");
            if (File.Exists(revortDepotsfile))
            {
                serviceResult.ErrorMessage = File.ReadAllText(revortDepotsfile);
            }
            else
            {
                File.WriteAllText(revortDepotsfile, "C-8B-H1;C-8A-H1;C-8B-H2;C-8A-H2");
                serviceResult.ErrorMessage = "C-8B-H1;C-8A-H1;C-8B-H2;C-8A-H2";
            }
            return serviceResult;
        }

        public ServiceResult<List<PackageTypeModel>> GetPackageTypes(Token token)
        {
            ServiceResult<List<PackageTypeModel>> res = new ServiceResult<List<PackageTypeModel>>();
            List<PackageTypeModel> resp = null;
            UTerminalService.ServiceRequestOfInt32 param = new UTerminalService.ServiceRequestOfInt32();
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.CoId = token.CoId;
            param.Token.BranchId = token.BranchId;

            UTerminalService.ServiceResultOfListOfPackageTypeOut result = utermserv.GetPackageTypes(param);
            if (result != null)
            {
                //Logger.WriteFileLog(new StringBuilder().Append("Ambalaj bilgisi:").Append("Detay:").Append(Logger.ToXml(result)).ToString());
                res.Success = result.Result;
                if (result.Result)
                {
                    resp = new List<PackageTypeModel>();
                    foreach (var item in result.Value)
                    {
                        PackageTypeModel packageType = new PackageTypeModel();
                        packageType.PackageTypeId = item.PackageTypeId;
                        packageType.PackageTypeCode = item.PackageTypeCode;
                        packageType.PackageTypeDesc = item.PackageTypeDesc;

                        resp.Add(packageType);
                    }
                }
                res.ErrorMessage = result.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = resp;
            return res;
        }

        public ServiceResult<List<PackageDetailModel>> GetPackageMInfo(Token token, string packageNo)
        {

            ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
            List<PackageDetailModel> resp = null;

            UTerminalService.ServiceRequestOfInPacKageM param = new UTerminalService.ServiceRequestOfInPacKageM();

            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;
            param.Token.BranchId = token.BranchId;
            param.Value = new InPacKageM();

            param.Value.WhouseId = token.WhouseId;// firstRead_WareHouseId;
            param.Value.PackageNo = packageNo;

            param.Value.HasInputCriteria = true;
            param.Value.InputOutputCriteria = 1 /*InputOutput.Giriş*/;

            UTerminalService.ServiceResultOfOutPacKageD result = utermserv.GetPackageMInfo(param);

            if (result != null)
            {
                //Logger.WriteFileLog(new StringBuilder().Append("Ambalaj bilgisi:").Append("Detay:").Append(Logger.ToXml(result)).ToString());
                res.Success = result.Result;
                if (result.Result)
                {
                    resp = new List<PackageDetailModel>();
                    PackageDetailModel packageInf = new PackageDetailModel();
                    packageInf.ItemId = result.Value.ItemId;
                    packageInf.PackageNo = result.Value.PackageNo;
                    packageInf.PackageMId = result.Value.PackageMId;
                    packageInf.Qty = result.Value.Qty;
                    packageInf.UnitId = result.Value.UnitId;
                    packageInf.LotId = result.Value.LotId;
                    packageInf.LotCode = result.Value.LotCode;
                    packageInf.ColorId = result.Value.ColorId;
                    packageInf.ColorCode = result.Value.ColorCode;
                    packageInf.QualityId = result.Value.QualityId;
                    packageInf.QualityCode = result.Value.QualityCode;
                    packageInf.ItemAttribute1Code = result.Value.ItemAttribute1Code;
                    packageInf.ItemAttribute2Code = result.Value.ItemAttribute2Code;
                    packageInf.ItemAttribute3Code = result.Value.ItemAttribute3Code;
                    packageInf.HasDetail = result.Value.HasDetail;
                    packageInf.Revort = result.Value.Revort;
                    packageInf.EntityId = result.Value.EntityId;
                    packageInf.EntityName = result.Value.EntityName;
                    packageInf.PackageTypeId = result.Value.PackageTypeId;
                    packageInf.FreePrmMId = result.Value.FreePrmMId;
                    packageInf.GrossWeight = result.Value.GrossWeight;
                    packageInf.NetWeight = result.Value.NetWeight;

                    resp.Add(packageInf);
                }
                res.ErrorMessage = result.Message;
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            res.Result = resp;
            return res;
        }

        public ServiceResult<bool> PrintBarcode(Token token, string barcode)
        {
            ServiceRequestOfString param = new ServiceRequestOfString();
            ServiceResult<bool> res = new ServiceResult<bool>();
            param.Value = barcode;
            param.Token = new UTerminalService.Token();
            param.Token.UserName = token.Username;
            param.Token.Password = token.Password;

            UTerminalService.ServiceResultOfBoolean response = utermserv.PackageBarcodePrint(param);

            if (response != null)
            {
                if (response.Result)
                {
                    res.Result = response.Value;
                    res.Success = response.Result;
                }
                else
                {
                    res.Result = response.Value;
                    res.Success = false;
                    res.ErrorMessage = response.Message;
                }
            }
            else
            {
                res.Success = false;
                res.ErrorMessage = "Sunucu yanıt vermedi!";
            }

            return res;
        }

    }
}