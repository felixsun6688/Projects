using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;
using System;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class NewTableBookingToEntity : ITypeConverter<NewTableBookingDto, Domain.Core.Model.TableBooking>
    {
        public Domain.Core.Model.TableBooking Convert(NewTableBookingDto source, 
                                                                                    Domain.Core.Model.TableBooking destination, 
                                                                                    ResolutionContext context)
        {
            DateTime date = System.Convert.ToDateTime(source.Bookingdate);
            DateTime time = System.Convert.ToDateTime(source.Bookingtime);

            DateTime bookingDate = new DateTime(date.Year, date.Month, date.Day,
                                                                           time.Hour, time.Minute, 0, DateTimeKind.Local);

            return new Domain.Core.Model.TableBooking(source.Id,
                                                                                   CreateBookingNumber(6),
                                                                                   source.Numberofadults,
                                                                                   source.Numberofchildren,
                                                                                   bookingDate,
                                                                                   source.Firstname,
                                                                                   source.Lastname,
                                                                                   source.Phonenumber,
                                                                                   source.Email,
                                                                                   source.Request,
                                                                                   DateTime.Now,
                                                                                   TableBookingStatus.Booked);
        }

        private static int getNewSeed()
        {
            byte[] rndBytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes, 0);
        }

        private string CreateBookingNumber(int length)
        {
            string str = "123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
            string reValue = string.Empty;
            Random rnd = new Random(getNewSeed());
            while (reValue.Length < length)
            {
                string s = str[rnd.Next(0, str.Length)].ToString();
                if (reValue.IndexOf(s) == -1) reValue += s;
            }
            return reValue;
        }
    }
}
