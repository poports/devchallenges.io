import React from 'react'
import tw from 'twin.macro'
import { Button } from './components'
import 'tailwindcss/dist/base.min.css'

export default () => (
  <div
    css={[
      tw`flex flex-col items-center justify-center h-screen`,
      tw`bg-gradient-to-b from-electric to-ribbon`
    ]}
  >
    <div tw="flex flex-col justify-center h-full space-y-5">
      <Button isPrimary>Send</Button>
      <Button isSecondary>Cancel</Button>
      <Button isSmall>Close</Button>
    </div>
  </div>
)
