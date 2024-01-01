import { http } from "..";

export function getAllImport(){
    return http.get(`/importing`);
}

export function createImport(newImport: any){
    return http.post(`/importing`, newImport)
}