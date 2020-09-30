import React from 'react'
import { Route, Switch } from 'react-router-dom'
import { Theme } from './components'
import Home from './pages/Home'
import Profile from './pages/Profile'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute'
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes'
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants'
import { Navigation } from './components'

export const UserContext = React.createContext()

const userContext = {
  isAuthenticated: false,
  userPhoto: null
}

export default () => {
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
