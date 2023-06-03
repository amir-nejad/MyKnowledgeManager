import { Component, OnInit } from '@angular/core';
import { Constants } from '../../../configs/constants';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {

  pageTitle: string = "Error!";
  errorMessage: string = "";

  constructor(private titleService: Title) { }

  ngOnInit(): void {
    this.pageTitle = localStorage.getItem(Constants.localStorageErrorPageTitleKey) ?? this.pageTitle;
    this.errorMessage = localStorage.getItem(Constants.localStorageErrorKey) ?? this.errorMessage;

    this.titleService.setTitle(this.pageTitle);
  }

}
