using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SystemConfig
    {
        public int Id { get; set; }
        public string TFSProject { get; set; }
        public string TFSIterationPath { get; set; }
        public string TFSCollectionUrl { get; set; }
        public DateTime? TFSScrumStartDate { get; set; }
        public DateTime? TFSScrumEndDate { get; set; }
        public string TFSSprintName { get; set; }
        // PAT Personal Access Token (Get it press on Account Image on TFS and Press Security and Create Personal Access ) 
        // PAT is valid for one Year Start from 8 Mars 2022
        public string TFSPAT { get; set; }
        public string FullSiteURL { get; set; }
        public string AmazonS3CDN { get; set; }
    }
}
