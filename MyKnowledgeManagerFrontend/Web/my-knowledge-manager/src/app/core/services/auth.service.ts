import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Subject, BehaviorSubject } from 'rxjs';
import { Constants } from '../../configs/constants';


/**
 * This service provides all functions related to authentication and manage all user policies and security.
 */
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _userManager: UserManager;
  private _user: User | undefined;
  private _loginChangedSubject$ = new BehaviorSubject<boolean>(false);

  public loginChanged$ = this._loginChangedSubject$.asObservable();

  // Declaration of some initial settings needed for UserManager service.
  private get idpSettings(): UserManagerSettings {
    return {
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/authentication/signin-callback`,
      scope: "openid profile webApi",
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/authentication/signout-callback`
    }
  }

  constructor() {
    this._userManager = new UserManager(this.idpSettings);
  }

  /**
   * This function is used for redirecting user to the sign-in page.
   * @returns void
   */
  public login = () => {
    return this._userManager.signinRedirect();
  }

  /**
   * This function defined to check if user authenticated or not.
   * @returns True if user is authenticated and False if not.
   */
  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        if (this._user !== user) {
          this._loginChangedSubject$.next(this.checkUser(user!));
        }

        this._user = user!;
        return this.checkUser(user!);
      })
  }

  /**
   * This function defined to finish the login process.
   * @returns The logged-in user object.
   */
  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback()
      .then(user => {
        this._user = user;
        this._loginChangedSubject$.next(this.checkUser(user));
        return user;
      })
  }

  /**
 * This function is used for redirecting user to the sign-out page.
 * @returns void
 */
  public logout = () => {
    this._userManager.signoutRedirect();
  }

  /**
 * This function defined to finish the logout process.
 * @returns The logged-in user object.
 */
  public finishLogout = () => {
    this._user = undefined;
    return this._userManager.signoutRedirectCallback();
  }

  /**
   * This function is used for getting an access token for the current user, and can have access to the restricted api resources.
   * @returns Access Token or Null
   */
  public getAccessToken = (): Promise<string | null> => {
    return this._userManager.getUser()
      .then(user => {
        return user != null && !user.expired ? user.access_token : null;
      })
  }

  /**
   * This function can get the current user Id.
   * @returns The Id of the current user if user is valid, otherwise null.
   */
  public getUserId = (): Promise<string | null> => {
    return this._userManager.getUser()
      .then(user => {
        return !!user && !user.expired ? user.profile.sub : null;
      });
  }

  /**
   * This function can check if a user is valid or not.
   * @param user The target user for validation.
   * @returns True if user is valid, otherwise False.
   */
  private checkUser = (user: User): boolean => {
    console.log(user);
    return !!user && !user.expired;
  }
}
