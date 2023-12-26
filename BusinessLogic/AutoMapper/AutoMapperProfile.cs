using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Entities;

namespace BusinessLogic.AutoMapper
{
    public class AutoMapperProfile : Profile, IAutoMapperProfile
    {
        public AutoMapperProfile()
        {
            CreatePostOfficeMap();

            CreateStaffMap();

            CreateShipmentMarkMap();

            CreateParcelMap();

            CreateParcelItemMap();

            CreateItemCategoryMap();

            CreateCategoryMarkMap();

            CreateParcelStatusHistoryMap();

            CreateClientMap();

            CreateOwnedMap();
        }

        private void CreatePostOfficeMap()
        {
            CreateMap<PostOffice, PostOfficeModel>()
                //.ForMember(pom => pom.OfficeStaffId, 
                //    po => po.MapFrom(x => x.OfficeStaff.Select(os => os.Id)))
                //.ForMember(pom => pom.ReceiveParcelsId, 
                //    po => po.MapFrom(x => x.ReceiveParcels.Select(rp => rp.Id)))
                //.ForMember(pom => pom.SendParcelsId, 
                //    po => po.MapFrom(x => x.SendParcels.Select(rp => rp.Id)))
                .ReverseMap()
                .ForMember(po => po.Id, opt => opt.Condition(pom => pom.Id != null))
                .ForMember(po => po.OfficeStaff, opt => opt.Ignore())
                .ForMember(po => po.ReceiveParcels, opt => opt.Ignore())
                .ForMember(po => po.SendParcels, opt => opt.Ignore());
        }

        private void CreateStaffMap()
        {
            CreateMap<Staff, StaffModel>()
                .ReverseMap()
                .ForMember(s => s.PasswordHash, opt => opt.Ignore())
                .ForMember(s => s.Id, opt => opt.Condition(sm => sm.Id != null))
                .ForMember(s => s.PostOffice, opt => opt.Ignore());
        }

        private void CreateShipmentMarkMap()
        {
            CreateMap<ShipmentMark, ShipmentMarkModel>()
                //.ForMember(smm => smm.CategoryMarksId,
                //    sm => sm.MapFrom(x => x.CategoryMarks.Select(cm => cm.CategoryId)))
                .ReverseMap()
                .ForMember(sm => sm.Id, opt => opt.Condition(smm => smm.Id != null))
                .ForMember(sm => sm.CategoryMarks, opt => opt.Ignore());
        }

        private void CreateParcelMap()
        {
            CreateMap<Parcel, ParcelModel>()
                //.ForMember(pm => pm.ParcelFillingId,
                //    p => p.MapFrom(x => x.ParcelFilling.Select(pf => pf.Id)))
                //.ForMember(pm => pm.ParcelHistoryId,
                //    p => p.MapFrom(x => x.ParcelHistory.Select(ph => ph.Id)))
                .ReverseMap()
                .ForMember(p => p.Id, opt => opt.Condition(pm => pm.Id != null))
                .ForMember(p => p.ParcelFilling, opt => opt.Ignore())
                .ForMember(p => p.ParcelHistory, opt => opt.Ignore());
        }

        private void CreateParcelItemMap()
        {
            CreateMap<ParcelItem, ParcelItemModel>()
                .ReverseMap()
                .ForMember(pi => pi.Id, opt => opt.Condition(pim => pim.Id != null))
                .ForMember(pi => pi.ItemCategory, opt => opt.Ignore())
                .ForMember(pi => pi.Parcel, opt => opt.Ignore());
        }

        private void CreateItemCategoryMap()
        {
            CreateMap<ItemCategory, ItemCategoryModel>()
                //.ForMember(icm => icm.CategoryMarksId,
                //    ic => ic.MapFrom(x => x.CategoryMarks.Select(cm => cm.MarkId)))
                //.ForMember(icm => icm.ParcelItemsId,
                //    ic => ic.MapFrom(x => x.ParcelItems.Select(pi => pi.Id)))
                .ReverseMap()
                .ForMember(ic => ic.Id, opt => opt.Condition(icm => icm.Id != null))
                .ForMember(ic => ic.CategoryMarks, opt => opt.Ignore())
                .ForMember(ic => ic.ParcelItems, opt => opt.Ignore());
        }

        private void CreateCategoryMarkMap()
        {
            CreateMap<CategoryMark, CategoryMarkModel>()
                .ReverseMap();
        }

        private void CreateParcelStatusHistoryMap()
        {
            CreateMap<ParcelStatusHistory, ParcelStatusHistoryModel>()
                .ReverseMap()
                .ForMember(psh => psh.Id, opt => opt.Condition(pshm => pshm.Id != null))
                .ForMember(psh => psh.Parcel, opt => opt.Ignore());
        }

        private void CreateClientMap()
        {
            CreateMap<Client, ClientModel>()
                //.ForMember(cm => cm.AddressedParcelsId,
                //    c => c.MapFrom(x => x.AddressedParcels.Select(ap => ap.Id)))
                //.ForMember(cm => cm.SentParcelsId,
                //    c => c.MapFrom(x => x.SentParcels.Select(sp => sp.Id)))
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Condition(cm => cm.Id != null))
                .ForMember(c => c.AddressedParcels, opt => opt.Ignore())
                .ForMember(c => c.SentParcels, opt => opt.Ignore());
        }

        private void CreateOwnedMap()
        {
            CreateMap<PostOffice.Address, PostOfficeModel.AddressModel>()
                .ReverseMap();

            CreateMap<ParcelItem.Gabarites, ParcelItemModel.GabaritesModel>()
                .ReverseMap();
        }
    }
}
