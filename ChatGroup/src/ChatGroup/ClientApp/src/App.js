import React, { useEffect, createContext } from 'react'
import { Route, Switch } from 'react-router-dom'
import authService from './components/api-authorization/AuthorizeService'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute'
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes'
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants'

import Home from './pages/home'

export const UserContext = createContext()

const userContext = {
  isAuthenticated: false,
  user: null,
  token: null
}

const App = () => {
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

    return () => {
      authService.unsubscribe(subscription)
    }
  })

  return (
    <UserContext.Provider value={userContext}>
      <div>Nav bar</div>
      <Switch>
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
        <AuthorizeRoute exact path="/" component={Home} />
      </Switch>
    </UserContext.Provider>
  )
}

export default App
