using Purchasing.Contracts;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Repository
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PurchaseOrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        /*public async Task<bool> AddToCart(PurchaseOrderDetailDto purchaseOrderDetailDto)
        {
            try
            {
                var cartItem = await _repositoryManager.POrderDetail.GetPODetailsAsync(purchaseOrderDetailDto.PurchaseOrderID, purchaseOrderDetailDto.ProductID, trackChanges: true);
                if (cartItem == null)
                {
                    PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                    purchaseOrderDetail.PurchaseOrderID = cartItem.PurchaseOrderID;
                    purchaseOrderDetail.ProductID = cartItem.ProductID;
                    purchaseOrderDetail.OrderQty = 1;
                    purchaseOrderDetail.DueDate = DateTime.Now;

                    _repositoryManager.POrderDetail.CreatePOrderDetailsAsync(purchaseOrderDetail);
                    //await _repositoryManager.SaveAsync();
                }
                *//*else
                {
                    
                }*//*
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

        public async Task<PurchaseOrderDetail> AddToCart(int purchaseOrderDetailID, int productQty)
        {
            VPurchaseOrder vPurchaseOrder = new VPurchaseOrder();
            PurchaseOrderDetail orderDetail = new PurchaseOrderDetail();
            //vPurchaseOrder = await _repositoryManager.PurchaseOrder.GetAllPurchaseOrderAsync(trackChanges: true);
            vPurchaseOrder = await _repositoryManager.PurchaseOrder.GetPuchaseOrdersAsync(purchaseOrderDetailID, trackChanges: true);
            //orderDetail = await _repositoryManager.POrderDetail.GetPODetailsAsync(purchaseOrderDetailID, productQty, trackChanges: true);
            try
            {
                orderDetail = await _repositoryManager.POrderDetail.GetPODetailsAsync(vPurchaseOrder.PurchaseOrderID, productQty, trackChanges: true);
                if (vPurchaseOrder == null)
                {
                    vPurchaseOrder = new VPurchaseOrder();
         
                    //orderDetail = await _repositoryManager.POrderDetail.GetPODetailsAsync(vPurchaseOrder.PurchaseOrderID, vPurchaseOrder.ProductID, trackChanges: true);
                    orderDetail.PurchaseOrderID = vPurchaseOrder.PurchaseOrderID;
                    orderDetail.ProductID = vPurchaseOrder.ProductID;
                    orderDetail.DueDate = DateTime.Now;
                    orderDetail.OrderQty = 1;
                    orderDetail.UnitPrice = vPurchaseOrder.UnitPrice;
                    _repositoryManager.POrderDetail.CreatePOrderDetailsAsync(orderDetail);
                   // _repositoryManager.SaveAsync();

                }
                else
                {
                    //orderDetail = new PurchaseOrderDetail();
                    orderDetail.PurchaseOrderID = vPurchaseOrder.PurchaseOrderID;
                    orderDetail.ProductID = vPurchaseOrder.ProductID;
                    orderDetail.OrderQty += 1;
                    //_repositoryManager.SaveAsync();

                }
                return orderDetail;
            }
            catch (Exception ex)
            {
                //return ex.Message();
                throw;
            }

        }



    }
}
