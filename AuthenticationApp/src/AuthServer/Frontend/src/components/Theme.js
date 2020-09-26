import React from 'react'
import { ThemeProvider } from 'styled-components'
import resolveConfig from 'tailwindcss/resolveConfig'
import tailwindConfig from './../tailwind.config'
import tw from 'twin.macro'

const ScreenHeight = tw.div`
  flex flex-col items-center justify-center min-h-screen 
`
const { theme } = resolveConfig(tailwindConfig)
export default (props) => (
  <ThemeProvider {...props} {...{ theme }}>
    <ScreenHeight>{props.children}</ScreenHeight>
  </ThemeProvider>
)
