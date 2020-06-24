import address from './address'

export default interface Venue{
    Id: number,
    Name: string,
    IsClub: boolean,
    Address: address
}