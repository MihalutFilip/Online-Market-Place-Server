using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Domain.DatabaseEntities;
using OnlineMarketPlace.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.WebApi.Helpers
{
    public sealed class Mapper
    {
        private static readonly Mapper instance = new Mapper();

        private Mapper()
        {
        }

        public static Mapper Instance
        {
            get
            {
                return instance;
            }
        }

        public UserViewModel ToUserViewModel(User user, string jwtToken = null)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Username = user.Username,
                ColorCode = user.ColorCode,
                JwtToken = jwtToken
            };
        }

        public User ToUser(UserViewModel user)
        {
            return new User()
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Username = user.Username,
                Password = user.Password,
                ColorCode = user.ColorCode
            };
        }

        public ProductTypeViewModel ToProductTypeViewModel(ProductType productType)
        {
            return new ProductTypeViewModel()
            {
                Id = productType.Id,
                Name = productType.Name,
                Description = productType.Description,
                AttributeTypes = productType.AttributeTypes.Select(a => ToAttributeTypeViewModel(a)).ToList()
            };
        }

        public ProductType ToProductType(ProductTypeViewModel productType)
        {
            return new ProductType()
            {
                Id = productType.Id,
                Name = productType.Name,
                Description = productType.Description,
                AttributeTypes = productType.AttributeTypes.Select(a => ToAttributeType(a)).ToList()
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Price = product.Price,
                ImageBase64 = product.ImageBase64,
                User = ToUserViewModel(product.User),
                ProductTypeId = product.ProductTypeId,
                AttributeValues = product.AttributeValues.Select(a => ToAttributeValueViewModel(a)).ToList()
            };
        }

        public Product ToProduct(ProductViewModel product)
        {
            return new Product()
            {
                Id = product.Id,
                Price = product.Price,
                ImageBase64 = product.ImageBase64,
                User = product.User != null ? ToUser(product.User) : null,
                UserId = product.UserId,
                ProductTypeId = product.ProductTypeId,
                AttributeValues = product.AttributeValues.Select(a => ToAttributeValue(a)).ToList()
            };
        }

        public AttributeTypeViewModel ToAttributeTypeViewModel(AttributeType attributeType)
        {
            return new AttributeTypeViewModel()
            {
                Id = attributeType.Id,
                Name = attributeType.Name,
                DataType = attributeType.DataType
            };
        }

        public AttributeType ToAttributeType(AttributeTypeViewModel attributeType)
        {
            return new AttributeType()
            {
                Id = attributeType.Id,
                Name = attributeType.Name,
                DataType = attributeType.DataType
            };
        }

        public AttributeValueViewModel ToAttributeValueViewModel(AttributeValue attributeValue)
        {
            return new AttributeValueViewModel()
            {
                Id = attributeValue.Id,
                AttributeType = attributeValue.AttributeType != null ? ToAttributeTypeViewModel(attributeValue.AttributeType) : null,
                Value = attributeValue.Value
            };
        }

        public AttributeValue ToAttributeValue(AttributeValueViewModel attributeValue)
        {
            return new AttributeValue()
            {
                Id = attributeValue.Id,
                AttributeTypeId = attributeValue.AttributeType != null ? attributeValue.AttributeType.Id : attributeValue.AttributeTypeId,
                Value = attributeValue.Value
            };
        }

        public MessageViewModel ToMessageViewModel(Message message)
        {
            return new MessageViewModel()
            {
                Id = message.Id,
                Content = message.Content,
                ReceiverId = message.ReceiverId,
                SenderId = message.SenderId,
                SendTime = message.SendTime
            };
        }

        public Message ToMessage(MessageViewModel message)
        {
            return new Message()
            {
                Id = message.Id,
                Content = message.Content,
                ReceiverId = message.ReceiverId,
                SenderId = message.SenderId,
                SendTime = message.SendTime
            };
        }
    }
}
