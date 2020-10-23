import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`
  h-full bg-gray-200 dark:bg-gray-800 dark:text-gray-100
  flex flex-col
`
const MessageContainer = tw.div`p-12 m-2 flex-grow`
const FormContainer = tw.div`flex-none items-center mx-2 mb-2 `

const Form = tw.form`flex`
const MessageInput = tw.textarea`form-textarea
  flex-grow h-full text-gray-800 p-2 rounded-md shadow
  dark:bg-gray-700 dark:text-gray-100 
  light:border-indigo-500 dark:border-gray-700
`
const Submit = tw.button`m-2 w-16 rounded-md border-indigo-500 shadow-md`

const Main = () => {
  return (
    <Container>
      <MessageContainer>
        <h1>Message</h1>
      </MessageContainer>
      <FormContainer>
        <Form>
          <MessageInput />
          <Submit>Send</Submit>
        </Form>
      </FormContainer>
    </Container>
  )
}

export default Main
