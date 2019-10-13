import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    public games: Game[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router:Router) {
        http.get<Game[]>(baseUrl + 'game').subscribe(result => {
            this.games = result;
            console.log(this.games);
        }, error => console.error(error));
    }

    onEdit(id: number) {
        this.router.navigate(['/gameedit/'+id]);
    }
}

export interface Game {
  id: number;
  name: string;
  description: string;
  rating: number;
}
