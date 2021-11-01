import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/shared/contact.service';

@Component({
  selector: 'app-contact-datail-form',
  templateUrl: './contact-datail-form.component.html',
  styles: [
  ]
})
export class ContactDatailFormComponent implements OnInit {

  constructor(public service: ContactService) { }

  ngOnInit(): void {
  }

}
