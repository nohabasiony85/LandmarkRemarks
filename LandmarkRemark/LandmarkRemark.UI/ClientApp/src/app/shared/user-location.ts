import { IUserLocation } from "./user-location.interface";

export class UserLocation implements IUserLocation {
    public latitude: number;
    public longitude:number;
    public notes: string;
    public userId: number;
}
