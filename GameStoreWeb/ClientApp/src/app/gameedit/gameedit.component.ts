import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Game } from "../home/home.component";

@Component({
  selector: 'app-gameedit',
  templateUrl: './gameedit.component.html',
  styleUrls: ['./gameedit.component.css']
})
export class GameeditComponent implements OnInit {

    game: Game;

    constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.http.get<Game>(this.baseUrl + 'game/' + this.route.snapshot.params["id"]).subscribe(result => {
          this.game = result;
          console.log(this.game);
        }, error => console.error(error));
    }

}
