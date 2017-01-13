using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSAPSAPI.Models
{
  public class TrafficViolations
  {
    public int Id { get; set; }
    public int Code { get; set; }
    public int OffenceType { get; set; }
    public string Reference { get; set; }
    public string Legislation { get; set; }
    public string Penalty { get; set; }
    public DateTime AuditDte { get; set; }
    public string AuditUsr { get; set; }
  }
}