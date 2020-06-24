import axios from 'axios';
import IProfile from '@/types/profile';

export default class ProfileService{
    API_URL = process.env.VUE_APP_API_URL;

    public async getAllProfiles(): Promise<IProfile[]> {
        let result = await axios.get('http://localhost:5000/api/profiles')
        console.log(result.data);
        return result.data;
    }
}