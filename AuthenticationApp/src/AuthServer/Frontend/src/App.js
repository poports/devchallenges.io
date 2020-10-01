import React, { useEffect, createContext } from 'react'
import { Route, Switch } from 'react-router-dom'
import { Theme } from './components'
import Home from './pages/Home'
import Profile from './pages/Profile'
import authService from './components/api-authorization/AuthorizeService'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute'
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes'
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants'
import { Navigation } from './components'

export const UserContext = createContext()

const userContext = {
  isAuthenticated: false,
  user: '',
  token: '',
  userPhoto: null
}

export default () => {
  useEffect(() => {
    const populateState = async () => {
      const [isAuthenticated, user, token] = await Promise.all([
        authService.isAuthenticated(),
        authService.getUser(),
        authService.getAccessToken()
      ])

      if (!isAuthenticated) return
      userContext.isAuthenticated = isAuthenticated
      userContext.user = user.preferred_username
      userContext.token = token
    }

    const subscription = authService.subscribe(() => populateState())
    populateState()

    return function cleanup() {
      authService.unsubscribe(subscription)
    }
  })

  return (
    <UserContext.Provider value={userContext}>
      <Theme>
        <Navigation />
        <Switch>
          <AuthorizeRoute exact path="/profile" component={Profile} />
          <Route
            path={ApplicationPaths.ApiAuthorizationPrefix}
            component={ApiAuthorizationRoutes}
          />
          <Route exact path="/" component={Profile} />
        </Switch>
      </Theme>
    </UserContext.Provider>
  )
}
