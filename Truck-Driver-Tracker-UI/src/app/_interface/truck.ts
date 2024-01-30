export interface Driver {
    id: number;
    createdAt: Date;
    updatedAt: Date;
    siteId: number;
    driverId: number;
    name: string;
    employeeNumber: string;
  }

  
  export interface Truck {
    id: number;
    createdAt: Date;
    updatedAt: Date;
    siteId: number;
    assetId: number;
    registrationNumber: string;
    lastPositionTimestamp: Date;
    latitude: number;
    longitude: number;
    currentAddress: string;
    
  }
  
 