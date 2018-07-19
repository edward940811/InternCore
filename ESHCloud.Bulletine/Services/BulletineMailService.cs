using ESHCloud.Base.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.Services
{
    public class BulletineMailService : BaseRepository, IBulletineMailService
    {
        public void Save(BulletineMailViewModel model)
        {
            // 是否要設定信件通知

            // 如果是: 更新 Bulletine 的NotifyType(發送類型)、NofityDatetime、NotifyValue
            // TODO:驗證的NotifyType、NofityDatetime、NotifyValue

            // 更新 BulletineMail
            // Todo:驗證逗號分隔的 Mail 格式


            // 如果否: update Bulletine NotifyMail 為 false'

            throw new NotImplementedException();
        }
    }
}
