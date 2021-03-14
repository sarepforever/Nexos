import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from './services/book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  form:FormGroup;
  listBook:any;
  title = 'biblioteca';
  constructor(private fb:FormBuilder, private bookServices:BookService) {
  this.form = this.fb.group({
    shared:[''],
  })
  this.bookServices.getBook(this.form.controls.shared.value).subscribe( response => {
    console.log(response)
    this.listBook = response;

  })
  }
  bookSearch (value:any) {
    console.log(this.form.controls.shared.value)
    this.listBook = [

    ];
      this.bookServices.getBook(this.form.controls.shared.value).subscribe( response => {
        console.log(response)
        this.listBook = response;

      })
  }
}
