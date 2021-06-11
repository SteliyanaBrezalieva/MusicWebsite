using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        List<SongDTO> GetSongs(String filter);


        [OperationContract]
        string PostSong(SongDTO song);


        [OperationContract]
        string DeleteSong(int id);


        [OperationContract]
        SongDTO GetSongById(int id);

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>

        [OperationContract]
        List<SongStyleDTO> GetSongStyle();


        [OperationContract]
        string PostSongStyle(SongStyleDTO style);


        [OperationContract]
        string DeleteSongStyle(int id);


        [OperationContract]
        SongStyleDTO GetSongStyleById(int id);

        ////
        ///
        [OperationContract]
        List<SingerDTO> GetSingers(String filter);


        [OperationContract]
        string PostSinger(SingerDTO singer);


        [OperationContract]
        string DeleteSinger(int id);


        [OperationContract]
        SingerDTO GetSingerById(int id);
        ////////
        ///
        [OperationContract]
        List<UserDTO> GetUsers();


        [OperationContract]
        string PostUser(UserDTO user);


        [OperationContract]
        string DeleteUser(int id);


        [OperationContract]
        UserDTO GetUserById(int id);


    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
