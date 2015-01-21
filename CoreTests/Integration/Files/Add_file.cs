﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.ThirdParty.ServiceStack.Text;
using File = System.IO.File;

namespace CoreTests.Integration.Files
{
    [TestFixture]
    public class Add_file : ApiWrapperTest
    {
        private const string ImagePath = @"resources\images\connect_xero_button_blue.png";
        
        public string Id;
        
        public string folderId;

        [Test]
        public void can_get_all_files_like_this()
        {
           var result= Api.Files.All();

            Assert.True(result!=null);
        }

        [Test]
        public void can_get_single_file_like_this()
        {
            for_example();

            var folder = Api.Files[folderId];

            var file = folder[Id];

            Assert.IsTrue(file.Name == "10322846_10154310023545529_6907991459304884147_n.jpg");

            //Assert.IsTrue(folder.IsInbox );
            
            Assert.IsTrue(folder.Name == "Inbox");

        }

        private void for_example()
        {
            var result = Api.Files.All();

            folderId = result[0].FolderId;

            Id = result[0].Id;
        }


        //[Test]
        //public void Can_add_a_file_like_this()
        //{
        //    // get a file
        //    var myfile = File.Open(ImagePath, FileMode.Open);

        //    byte[] data = new byte[10000];


        //    for (int i = 0; i < myfile.Length; i++)
        //    {
        //        if (data[i] != myfile.ReadByte())
        //        {
        //            break;
        //        }
        //    }

           

        //    var result =  Api.Files.AddFile(new Xero.Api.Core.Model.File()
        //    {
        //        Name = "test",
        //        User = new FilesUser()
        //        {
        //            FirstName ="David",
        //            LastName ="Norden",
        //            FullName = "David Norden",
        //            Name = "David@gmail.com"

        //        }
        //    } ,   data);
            
           
        //}
    }
}