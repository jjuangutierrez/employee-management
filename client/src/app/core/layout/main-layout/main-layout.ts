import { Component } from '@angular/core';
import { SidebarComponent } from '../sidebar/sidebar';
import { RouterOutlet } from '@angular/router';
import { Header } from "../header/header";

@Component({
  selector: 'app-main-layout',
  imports: [SidebarComponent, RouterOutlet, Header],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.css'
})
export class MainLayout {

}
