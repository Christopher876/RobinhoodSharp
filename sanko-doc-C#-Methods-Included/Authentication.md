# Authentication Methods

- [Logging in](#logging-in)
- [Logging out](#logging-out)

## Logging in

The **Login** class contains:

**Fields**

| Parameter | Type   | Description   | Default | Required |
|-----------|--------|---------------|---------|----------|
| username  | String | Your username | N/A     | **Yes**  |
| password  | String | Uh, password  | N/A     | **Yes**  |
| accessToken | String | access token | N/A | **Yes**|
| refreshToken | String | refresh token
| tokenReceived | String | Time received access token
| tokenExpires | String | Time when token will expire (86400 seconds)

**Authenication.AuthenticateUser(Login login,Bool mfa)**
*Make sure that the Login class has both the login and password set*
If the user has mfa enabled(true) or not (false). It will save the token, refresh token, received and expires to a file called "access.txt".

Returns: string with the accessToken

**Authenication.AuthenticateUserMFA(Login login, string mfaCode)**
*Make sure that the Login class has both the login and password set*
This method will authenticate the mfa user and return the access token. It will save the token, refresh token, received and expires to a file called "access.txt".

Returns: string with the accessToken

**Authenication.CheckRefreshToken(Login)**
This method will check if it is time to refresh the token and get a new access token.
*Login.AccessToken and Login.refreshToken will be assigned the correct values*

<!--
## Logging out 

Every client that [logs in](#log-in) with your username/password is given the same token. For security, you can force it to expire with a call to log out.
-->