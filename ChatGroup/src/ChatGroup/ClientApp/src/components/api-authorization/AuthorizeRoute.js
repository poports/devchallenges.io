import React, { useState, useEffect } from 'react'
import { Route, Redirect } from 'react-router-dom'
import {
  ApplicationPaths,
  QueryParameterNames
} from './ApiAuthorizationConstants'
import authService from './AuthorizeService'

const AuthorizeRoute = ({ ...props }) => {
  const [ready, setReady] = useState(false)
  const [authenticated, setAuthenticated] = useState(false)

  useEffect(() => {
    const populateAuthenticationState = async () => {
      const authenticated = await authService.isAuthenticated()
      setReady(true)
      setAuthenticated(authenticated)
    }

    const authenticationChanged = async () => {
      setReady(false)
      setAuthenticated(false)
      await populateAuthenticationState()
    }

    const _subscription = authService.subscribe(() => authenticationChanged())
    populateAuthenticationState()

    return () => authService.unsubscribe(_subscription)
  })

  let link = document.createElement('a')
  link.href = props.path

  const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`
  const redirectUrl = `${ApplicationPaths.Login}?${
    QueryParameterNames.ReturnUrl
  }=${encodeURI(returnUrl)}`
  if (!ready) {
    return <div></div>
  } else {
    const { component: Component, ...rest } = props
    return (
      <Route
        {...rest}
        render={(props) => {
          if (authenticated) {
            return <Component {...props} />
          } else {
            return <Redirect to={redirectUrl} />
          }
        }}
      />
    )
  }
}
export default AuthorizeRoute
