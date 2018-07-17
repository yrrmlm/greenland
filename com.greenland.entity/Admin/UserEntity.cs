/**
* 命名空间: com.greenland.entity.User
*
* 功 能： 用户实体
* 类 名： UserEntity
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:17:56 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.entity.User
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Loginname { get; set; }

        public string Loginpwd { get; set; }

        public string Pwdsalt { get; set; }

        public int Isactive { get; set; }

        public DateTime Createtime { get; set; }

        public string Createby { get; set; }

        public DateTime Updatetime { get; set; }

        public string Updateby { get; set; }
    }
}
