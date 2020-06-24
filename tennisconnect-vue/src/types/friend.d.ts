export default interface Friend{
    RequestedById: number,
    RequestedToId: number,
    RequestTime: Date,
    BecameFriendsTime: Date,
    FriendRequestFlag: FriendRequestFlag
}

export enum FriendRequestFlag{
    None,
    Approved,
    Rejected
}