import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    public games: Game[];
    public popularity: boolean = true;
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router:Router) {
        http.get<Game[]>(baseUrl + 'game?mostPopular=true').subscribe(result => {
            this.games = result;
            console.log(this.games);
        }, error => console.error(error));
    }

    onEdit(id: number) {
        this.router.navigate(['/gameedit/'+id]);
    }

    togglePopularity() {
        this.popularity = !this.popularity;
        this.http.get<Game[]>(this.baseUrl + 'game?mostPopular='+this.popularity).subscribe(result => {
          this.games = result;
          console.log(this.games);
        }, error => console.error(error));

    }
}

export interface Game {
  id: number;
  name: string;
  description: string;
  rating: number;
}
