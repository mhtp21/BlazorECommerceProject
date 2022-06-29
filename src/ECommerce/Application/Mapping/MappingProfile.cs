using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Common.Models.Queries;
using Common.Models.RequestModels;
using Common.Models.RequestModels.Update;
using Common.Models.RequestModels.Delete;

namespace Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, LoginUserViewModel>().ReverseMap();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductDetailViewModel>().ReverseMap();

            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>();
            CreateMap<Brand, BrandDetailViewModel>().ReverseMap();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryDetailViewModel>().ReverseMap();

            CreateMap<CreateColorCommand,Color>();
            CreateMap<UpdateColorCommand, Color>();
            CreateMap<Color, ColorDetailViewModel>().ReverseMap();

            CreateMap<CreateEmailTailCommand, EmailTail>();
            CreateMap<UpdateEmailTailCommand,EmailTail>();
            CreateMap<EmailTail, EmailTailDetailViewModel>().ReverseMap();

            CreateMap<CreateOfferCommand, Offer>();
            CreateMap<UpdateOfferCommand, Offer>();
            CreateMap<Offer, OfferDetailViewModel>().ReverseMap();

            CreateMap<CreatePaymentCommand, Payment>();
            CreateMap<UpdatePaymentCommand, Payment>();
            CreateMap<Payment, PaymentDetailViewModel>().ReverseMap();

            CreateMap<CreatePurchaseCommand, Purchase>();
            CreateMap<UpdatePurchaseCommand, Purchase>();
            CreateMap<Purchase, PurchaseDetailViewModel>().ReverseMap();
        }
    }
}