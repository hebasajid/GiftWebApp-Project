using AutoMapper;
using GiftAPI.DTOs;
using GiftInfoLibraryy.Models;

namespace GiftAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            
         
            //mapping from giftInfo to the DTO
            CreateMap<GiftInfo, GiftInfoDto>(); 

            //mapping from UserInfo to its DTO
            CreateMap<ParentGift, ParentGiftsDto>(); 

            CreateMap<UserFavoriteGift, UserFavoriteGiftDto>();

            // reverse mappings:
            CreateMap<GiftInfoDto, GiftInfo>(); 

            CreateMap<ParentGiftsDto, ParentGift>();

            CreateMap<UserFavoriteGiftDto, UserFavoriteGift>();



        }
    }
}
