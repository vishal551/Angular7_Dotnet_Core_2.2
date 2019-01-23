import { Component, OnInit } from "@angular/core";
import { EmployeeService } from "src/app/shared/employee.service";
import { NgForm } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { Employee } from "src/app/shared/employee.model";

@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"]
})
export class EmployeeComponent implements OnInit {
  constructor(
    private service: EmployeeService,
    private toaster: ToastrService
  ) {}

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.service.formData = {
      id: null,
      FullName: "",
      Position: "",
      EMPCode: "",
      Mobile: ""
    };
  }
  onSubmit(form: NgForm) {
    debugger;
    if (form.value.id == null) this.InsertRecord(form);
    else this.updateRecord(form);
  }
  InsertRecord(form: NgForm) {
    this.service.postEmployee(form.value).subscribe(res => {
      this.toaster.success("inserted success fully..", "Employee Register");
      this.resetForm(form);
      this.service.getEmployee();
    });
  }
  updateRecord(form: NgForm) {
    this.service.putEmoloyee(form.value).subscribe(res => {
      this.toaster.success("update success fully..", "Employee Register");
      this.resetForm(form);
      this.service.getEmployee();
    });
  }
}
