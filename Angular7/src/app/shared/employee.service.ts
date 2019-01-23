import { Injectable } from "@angular/core";
import { Employee } from "./employee.model";
import { HttpClient, HttpHeaders } from "@angular/common/http";
@Injectable({
  providedIn: "root"
})
export class EmployeeService {
  formData: Employee;
  list: Employee[];
  // datatest:string;
  constructor(private http: HttpClient) {}
  postEmployee(formData: Employee) {
    formData.id = 0;
    const headers = new HttpHeaders().set(
      "content-type",
      "application/x-www-form-urlencoded"
    );

    return this.http.post(
      "http://localhost:57448/api/EmployeeDetail",
      this.getFormUrlEncoded(formData),
      {
        headers
      }
    );
  }
  getEmployee() {
    this.http
      .get("http://localhost:57448/api/EmployeeDetail")
      .toPromise()
      .then(res => (this.list = res as Employee[]));
  }
  putEmoloyee(formData: Employee) {
    const headers = new HttpHeaders().set(
      "content-type",
      "application/x-www-form-urlencoded"
    );
    debugger;
    return this.http.put(
      "http://localhost:57448/api/EmployeeDetail/" + formData.id,
      this.getFormUrlEncoded(formData),
      { headers }
    );
  }
  deleteEmployee(id) {
    return this.http.delete("http://localhost:57448/api/EmployeeDetail/" + id);
  }
  getFormUrlEncoded(toConvert) {
    const formBody = [];
    for (const property in toConvert) {
      const encodedKey = encodeURIComponent(property);
      const encodedValue = encodeURIComponent(toConvert[property]);
      formBody.push(encodedKey + "=" + encodedValue);
    }
    return formBody.join("&");
  }
}
