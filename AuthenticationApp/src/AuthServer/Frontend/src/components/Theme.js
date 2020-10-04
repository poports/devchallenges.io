import React from 'react'
import { ThemeProvider } from 'styled-components'
import resolveConfig from 'tailwindcss/resolveConfig'
import tailwindConfig from './../tailwind.config'

const { theme } = resolveConfig(tailwindConfig)
export default (props) => (
  <ThemeProvider {...props} {...{ theme }}>
    {props.children}
  </ThemeProvider>
)
