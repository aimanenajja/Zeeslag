import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AccessPass } from '../_models/access-pass.model';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private accessPassSubject: BehaviorSubject<AccessPass>;
  public accessPass$: Observable<AccessPass>;

  constructor(private http: HttpClient) {
    this.accessPassSubject = new BehaviorSubject<AccessPass>(JSON.parse(localStorage.getItem('accessPass')));
    this.accessPass$ = this.accessPassSubject.asObservable();
  }

  public get accessPass(): AccessPass {
    return this.accessPassSubject.value;
  }

  login(email: string, password: string) {
    return this.http
      .post<AccessPass>(`${environment.apiUrl}/authentication/token`, {
        email,
        password,
      })
      .pipe(
        map((accessPass) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('accessPass', JSON.stringify(accessPass));
          this.accessPassSubject.next(accessPass);
          return accessPass;
        })
      );
  }

  register(nickname: string, email: string, password: string) {
    return this.http.post<any>(`${environment.apiUrl}/authentication/register`, {
      nickname,
      email,
      password,
    });
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('accessPass');
    this.accessPassSubject.next(null);
  }
}
