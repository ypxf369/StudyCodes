using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Domain.Entities.Base;

namespace TPSite.Domain.Entities
{
    public class MessageRecord : EntityBaseFull<Guid>
    {
        public Guid FromUserId { get; set; }
        public User FromUser { get; set; }
        public Guid ToUserId { get; set; }
        public User ToUser { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
//USE[TPSite]
//GO

///****** Object:  Table [dbo].[MessageRecords]    Script Date: 2018/9/11/星期二 19:43:24 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[MessageRecords]
//(

//[Id][uniqueidentifier] NOT NULL,

//[IsDeleted] [bit]
//NOT NULL,

//[CreationTime] [datetime2] (7) NOT NULL,

//[LastModificationTime] [datetime2] (7) NULL,
//[DeletionTime] [datetime2] (7) NULL,
//[FromUserId]
//[uniqueidentifier]
//NOT NULL,

//[ToUserId] [uniqueidentifier]
//NOT NULL,

//[Message] [nvarchar] (4000) NOT NULL,
 
//[IsRead] [bit]
//NOT NULL
//) ON[PRIMARY]
//GO


