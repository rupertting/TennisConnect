import user from './user';
import address from './address';
import club from './club';
import friend from './friend';

export default interface IProfile{
    id: number,
    userModel: user,
    dateOfBirth: Date,
    address: address,
    club: club,
    rating: string,
    bio: string,
    sentFriendRequests:{
        [key: string]: friend
    },
    receivedFriendRequests:{
        [key: string]: friend
    }
    friends:{
        [key: string]: friend
    }
}