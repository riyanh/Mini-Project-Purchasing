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

        public async Task<bool> AddToCart(AddToCartDto addToCartDto)
        {
            PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();
            PurchaseOrderDetail orderDetail = new PurchaseOrderDetail();
            VPurchaseOrder vPurchaseOrder = new VPurchaseOrder();

            purchaseOrderHeader = await _repositoryManager.POrderHeader.GetPOHeaderAsync(addToCartDto.EmployeeID, trackChanges: true);
            orderDetail = await _repositoryManager.POrderDetail.GetPODetailsAsync(addToCartDto.ProductID, trackChanges: true);
            vPurchaseOrder = await _repositoryManager.PurchaseOrder.GetPuchaseOrdersAsync(addToCartDto.ProductID, trackChanges: true);

            try
            {
                if (purchaseOrderHeader.Status == 1)
                {
                    orderDetail = new PurchaseOrderDetail();
                    orderDetail.PurchaseOrderID = purchaseOrderHeader.PurchaseOrderID;
                    orderDetail.ProductID = addToCartDto.ProductID;
                    orderDetail.OrderQty += 1;
                    orderDetail.DueDate = DateTime.Now;
                    _repositoryManager.POrderDetail.UpdatePOrderDetailsAsync(orderDetail);
                    await _repositoryManager.SaveAsync();

                }
                else
                {
                    
                    purchaseOrderHeader = new PurchaseOrderHeader();
    
                    purchaseOrderHeader.EmployeeID = addToCartDto.EmployeeID;
                    purchaseOrderHeader.OrderDate = DateTime.Now;
                    purchaseOrderHeader.Status = 1;
                    purchaseOrderHeader.ShipMethodID = vPurchaseOrder.ShipMethodID;
                    purchaseOrderHeader.VendorID = vPurchaseOrder.BusinessEntityID;
                    _repositoryManager.POrderHeader.CreatePOrderHeaderAsync(purchaseOrderHeader);
                    await _repositoryManager.SaveAsync();


                    orderDetail = new PurchaseOrderDetail();
                    orderDetail.PurchaseOrderID = purchaseOrderHeader.PurchaseOrderID;
                    orderDetail.ProductID = addToCartDto.ProductID;
                    orderDetail.OrderQty = 1;
                    orderDetail.DueDate = DateTime.Now;
                    _repositoryManager.POrderDetail.CreatePOrderDetailsAsync(orderDetail);
                    await _repositoryManager.SaveAsync();

                }
                return true;
            }
            catch (Exception ex)
            {
                //return ex.Message();
                return false;
            }

        }



    }
}
