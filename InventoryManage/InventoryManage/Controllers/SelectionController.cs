using InventoryManage.Api_data;
using InventoryManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace InventoryManage.Controllers
{
    public class SelectionController : ApiController
    {
        InventoryDBEntities db = new InventoryDBEntities();

      

        [HttpPost]
        [Route("api/GetData")]
        public HttpResponseMessage GetData(barcodedata model)
        {
            var br = db.barcodedatas.FirstOrDefault(x => x.Barcode == model.Barcode);
            if (br != null)
            {
                barcodedata res = new barcodedata();
                res.Barcode = br.Barcode;
                res.ID = br.ID;
                res.Rid = br.Rid;
                res.Rcol = br.Rcol;

                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            else
            {
                barcodedata result = new barcodedata();
                result.Barcode = model.Barcode;
                String weiid = result.Barcode.Substring(0, 3);
                var wi = getWeight(weiid);
                var rackid = getRack(wi);
                result.Rid = rackid;

                String siid = result.Barcode.Substring(3, 6);
                var si = getSize(siid);
                String coid = result.Barcode.Substring(9, 3);
                var ci = getColor(coid);

                var rackcolid = getRackColId(si, ci);
                result.Rcol = rackcolid;

                String pid = result.Barcode.Substring(12,3);
                var pi = getProductId(pid);
                result.pid = pi;

                db.barcodedatas.Add(result);
                db.SaveChanges();

                barcodedata res = new barcodedata();
                res.Barcode = result.Barcode;
                res.ID = result.ID;
                res.Rid = result.Rid;
                res.Rcol = result.Rcol;


                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
        }

        public long getProductId(String pid)
        {
            var p = db.products.FirstOrDefault(x => x.productcode == pid);
            if(p!=null)
            {
                return p.Id;
            }
            else
            {
                product product = new product();
                product.productcode = pid;
                db.products.Add(product);
                db.SaveChanges();

                var pp = db.products.FirstOrDefault(x => x.productcode == pid);
                return pp.Id;
            }


        }



        public long getRackColId(long si ,long ci)
        {

            var rci = db.Rackcolumns.FirstOrDefault(x => x.sizeid == si && x.colorid == ci);
            if(rci !=null)
            {
                return rci.Id;
            }
            else
            {
                Rackcolumn rackcol = new Rackcolumn();
                rackcol.sizeid = si;
                rackcol.colorid = ci;
                db.Rackcolumns.Add(rackcol);
                db.SaveChanges();

                var rcb = db.Rackcolumns.FirstOrDefault(x => x.sizeid == si && x.colorid == ci);
                return rcb.Id;

            }



        }

        public long getColor(String coid)
        {
            var c = db.colors.FirstOrDefault(x => x.colorcode == coid);
            if(c != null)
            {
                return c.Id;
            }
            else
            {
                color color = new color();
                color.colorcode = coid;
                db.colors.Add(color);
                db.SaveChanges();

                var y = db.colors.FirstOrDefault(x => x.colorcode == coid);
                return y.Id;

            }

        }
        

        public long getSize(String siid)
        {
            var s = db.sizes.FirstOrDefault(x => x.Range == siid);
            if(s != null)
            {
                return s.Id;
            }
            else
            {
                size size = new size();
                size.Range = siid;
                db.sizes.Add(size);
                db.SaveChanges();

                var xo = db.sizes.FirstOrDefault(x => x.Range == siid);
                return xo.Id;

            }



        }

        public long getRack(long wi)
        {
            
            var ri = db.Racks.FirstOrDefault(x => x.weightid == wi);
            
            if(ri !=null)
            {
                return ri.Id;
            }
            else
            {
                Rack ra = new Rack();
                ra.weightid = wi;
                db.Racks.Add(ra);
                db.SaveChanges();

                var r = db.Racks.FirstOrDefault(x => x.weightid == wi);
                return r.Id;

            }
            
        }


       

        public long getWeight(String val)
        {

            var wid = db.weights.FirstOrDefault(x => x.weightcode==val);
            if(wid != null)
            {
                return wid.Id; 
            }
            else
            {
                weight wei = new weight();
                wei.weightcode = val;
                db.weights.Add(wei);
                db.SaveChanges();
              //  var w = await db.weights.FindAsync(db.weights.FirstOrDefault(x => x.weightcode == val));
                var w = db.weights.FirstOrDefault(x => x.weightcode ==val);
                return w.Id;


            }
        }






    }
}
