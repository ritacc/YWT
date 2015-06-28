using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.BLL.Coordinate;
using YWT.Model.Coordinate;
using YWT.Model.User;
using YWT.BLL.User;

namespace YWT.API
{
    /// <summary>
    /// YWT_UserInfo 的摘要说明
    /// </summary>
    public class YWT_UserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            string q0 = (context.Request["q0"]).TrimDangerousCharacter();
            string q1 = (context.Request["q1"]).TrimDangerousCharacter();
            string q2 = (context.Request["q2"]).TrimDangerousCharacter();
            string q3 = (context.Request["q3"]).TrimDangerousCharacter();
            string q4 = (context.Request["q4"]).TrimDangerousCharacter();
            string q5 = (context.Request["q5"]).TrimDangerousCharacter();
            string q6 = (context.Request["q6"]).TrimDangerousCharacter();
            string q7 = (context.Request["q7"]).TrimDangerousCharacter();
            string q8 = (context.Request["q8"]).TrimDangerousCharacter();
            string q9 = (context.Request["q9"]).TrimDangerousCharacter();
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write((new AjaxContentOR() { ReturnMsg = "no_action" }).ToJSON2());
                return;
            }
            switch (action.ToLower())
            {
                case "addupdate":
                    context.Response.Write(AddUpdate(q0, q1));
                    break;
                case "get":
                    context.Response.Write(GetUserInfo(q0));
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常" }).ToJSON2());
                    break;
            }
        }

        public string AddUpdate(string json, string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWTUserInfoOR _obj = json.ParseJSON<YWTUserInfoOR>();
                int mResultType = 0;
                string mResultMessage = "";
                if (_obj == null || string.IsNullOrEmpty(UserID))
                {
                    _result.ReturnMsg = "参数错误";
                }
                else
                {
                    _obj.Create_User = UserID;//操作人
                    new YWTUserInfoBLL().InsertUpdate(_obj,  out mResultType, out mResultMessage);

                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "参数错误";
                    }
                    else
                    {
                        _result.Status = false;
                        _result.ReturnMsg = mResultMessage;
                    }
                    _result.ResultObject = _obj;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_UserInfo.ashx/YWT_UserInfo", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public string GetUserInfo(string id)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _result.ReturnMsg = "参数错误。";
                }
                else if (id.Length != 36)
                {
                    _result.ReturnMsg = "参数错误:36";
                }
                else
                {
                    YWTUserInfoOR obj = new YWTUserInfoBLL().SelectARowDate(id);
                    if (obj == null)
                    {
                        _result.Status = false;
                        _result.ReturnMsg = "无法获取到对象";
                    }
                    else
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "Success";
                        _result.ResultObject = obj;
                    }
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_UserInfo.ashx/GetUserInfo", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

/*
 * 
DECLARE @Inerface_ID	BIGINT		
,@IFile			VARCHAR(50)='YWT_UserInfo.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addupdate','修改用户数据 ,第二步提交：姓名，性别，出生年月、邮箱。完成注册。到个人资料里再完善就可以了。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维人员 Josn 数据
 YWTUser_ID  用户ID，与注册的ID一样
 UserName   姓名
 User_Sex   性别
 Location_Province 所在地-省
 Location_City 所在地-市
 Location_County 所在地-区
 Birthday 出生年月日
 User_Address 详细地址
 Email Email
 HighestEducation 最高学历
 Finish_School 毕业学院
 SpecialtyName 专业名称
 GraduationData 毕业时间
 SkillDescription 技能描述
 Specialty 专长')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:当前操作人ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'get','根据ID查询一个运维人员用据。用于修改，查看。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维商ID')
  

 

 */