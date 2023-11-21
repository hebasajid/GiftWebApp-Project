using AutoMapper;
using GiftAPI.DTOs;
using GiftInfoLibrary.Models;

namespace GiftAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            
         
            //mapping from giftInfo to the DTO
            CreateMap<GiftInfo, GiftInfoDto>(); 

            //mapping from UserInfo to its DTO
            CreateMap<UserInfo, UserInfoDto>(); 

            CreateMap<UserFavoriteGift, UserFavoriteGiftDto>();

            // reverse mappings:
            CreateMap<GiftInfoDto, GiftInfo>(); 

            CreateMap<UserInfoDto, UserInfo>();

            CreateMap<UserFavoriteGiftDto, UserFavoriteGift>();



        }
    }
}
